using mqtt;
using SanSensNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MQTT
{
    
    public partial class MqttWinclient : Form
    {
        serversettings _serversett;
        Mqttclient_handler mqtt;
        protected BindingList<MqttTopic> topics = new BindingList<MqttTopic>();
        MqttTopic _currenttopic = null;
        string settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MqttManager");
        string _settingsfilepath = null;     //fichier à partir duquel le paramétrage a été éventuellemnt chargé
        string _messagepersistfile = null;     //fichier vers lequel sont éventuellement sauvegardés les messages entratns
        Timer tcheckconnection;
        public MqttWinclient()
        {
            InitializeComponent();

            displaystate(false);

            serversett = new serversettings();
            propertyGrid3.SelectedObject = serversett;
            propertyGrid3.PropertyValueChanged += PropertyGrid3_PropertyValueChanged;
            mqtt = new Mqttclient_handler();
            this.dataGridView_topics.DataSource = topics;
            this.dataGridView_topics.CellContentClick += DataGridView_topics_CellValueChanged;
            this.dataGridView_topics.CellValueChanged += DataGridView_topics_CellValueChanged1;
            //this.dataGridView_topics.SelectionChanged += DataGridView_topics_SelectionChanged;
            this.dataGridView_topics.CurrentCellChanged += DataGridView_topics_CurrentCellChanged;
            this.dataGridView_topics.Columns[0].Width = 130;
            this.dataGridView_topics.Columns[1].Width = 60;
            this.dataGridView_topics.Columns[2].Width = 30;
            this.dataGridView_topics.MouseClick += DataGridView_topics_MouseClick;
            this.dataGridView_topics.CursorChanged += DataGridView_topics_CursorChanged;
            this.FormClosing += MqttManager_FormClosing;
            addExistingsettingsToMenu();
            saveSettingsToolStripMenuItem.Enabled = false;
            this.splitContainer1.Panel1.Click += disableControlClick;
            this.splitContainer2.Panel2.Click += disableControlClick;
            plugExternalEvents();
        }


        private void plugExternalEvents()
        {
            bool extev_raisDisconnected = false;
            MessPublishEventArgs extev_messageArrived = null;
            mqtt.OnConnected += Mqtt_OnConnected;
            mqtt.OnDisconnected += (Mqttclient_handler sender, EventArgs e) =>
                {
                    extev_raisDisconnected = true;
                };

            mqtt.OnMessageArrived += (Mqttclient_handler sender, MessPublishEventArgs e) =>
                {
                    extev_messageArrived = e;
                };

            //to manage ext events by the UI thread
            tcheckconnection = new Timer();
            tcheckconnection.Interval = 200;
            tcheckconnection.Tick += (s, e) =>
            {
                if (extev_raisDisconnected)
                {
                    extev_raisDisconnected = false;
                    this.toolStripStatusLabel_server.BackColor = Color.Gray;
                    displaystate(false);
                }
                if (extev_messageArrived != null)
                {
                    this.DisplayMessage(extev_messageArrived.Message);
                    if (!string.IsNullOrEmpty(MessagepersistFile))
                    {
                        if (receivedmessages == null)
                            receivedmessages = new List<MqttMessage>();
                        receivedmessages.Add(extev_messageArrived.Message);
                        if (receivedmessages.Count > 20)
                            PersistsMessages(MessagepersistFile, receivedmessages);
                    }
                    extev_messageArrived = null;
                }
            };
            tcheckconnection.Enabled = true;
        }




        private void PropertyGrid3_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Type settingtype = typeof(serversettings);
            var pi = settingtype.GetProperty(e.ChangedItem.Label);
            pi.SetValue(serversett, pi.GetValue(this.propertyGrid3.SelectedObject));
        }

        private void disableControlClick(object sender, EventArgs e)
        {
            if (!this.splitContainer1.Panel1.Enabled)
            {
                MessageBox.Show("To enable this control, please connect to the broker");
            }
        }

        public serversettings serversett
        {
            get { return _serversett; }
            set
            {
                _serversett = value;
                propertyGrid3.SelectedObject = serversett;
                this.propertyGrid3.Refresh();
            }
        }


        /// <summary>
        /// fichier à partir duquel le paramétrage a été éventuellemnt chargé
        /// </summary>
        public string settingsfilepath
        {
            get { return _settingsfilepath; }
            set
            {
                _settingsfilepath = value;
                this.saveSettingsToolStripMenuItem.Text = "Save settings : " + value;
                this.saveSettingsToolStripMenuItem.Enabled = true;
            }
        }
        public string MessagepersistFile
        {
            get { return _messagepersistfile; }
            set
            {
                _messagepersistfile = value;
            }
        }

        public MqttTopic currenttopic
        {
            get
            {

                return _currenttopic;
            }
            set
            {
                _currenttopic = value;
                if (((MqttTopic)this.dataGridView_topics.CurrentRow.DataBoundItem).Path != value.Path)
                    foreach (DataGridViewRow r in this.dataGridView_topics.Rows)
                    {
                        if (((MqttTopic)r.DataBoundItem).Path == value.Path)
                        {
                            this.dataGridView_topics.CurrentCell = r.Cells[0];
                            break;
                        }
                    }
            }
        }

        private void MqttManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mqtt.IsConnected)
                mqtt.Disconnect();
            mqtt.Dispose();
            this.Dispose();
        }
        List<MqttMessage> receivedmessages = null;





        private void Mqtt_OnConnected(Mqttclient_handler sender, EventArgs e)
        {
            foreach (var t in topics.Where(a => a.Subscribed))
            {
                mqtt.subscribe(t.Path, t.Qos);
            }

            this.toolStripStatusLabel_server.BackColor = Color.Green;
            displaystate(true);
        }


        private void displaystate(bool enable)
        {
            this.splitContainer1.Panel1.Enabled = enable;
            this.connecterToolStripMenuItem.Enabled = !enable;
            this.déconnecterToolStripMenuItem.Enabled = enable;
            this.subscribeAllTopicsToolStripMenuItem.Enabled = enable;
            this.unsubscribeAllTopicsToolStripMenuItem.Enabled = enable;
            this.dataGridView_topics.Enabled = enable;
            this.sanSensNetToolStripMenuItem.Enabled = enable;
            // this.splitContainer2.Panel2.Enabled = enable;
        }

        private void Connect()
        {
            try
            {
                mqtt.MqttConnect(this.serversett.ServerName, this.serversett.ClientName,
                     this.serversett.UserName, this.serversett.Password, this.serversett.willRetain, this.serversett.willQos, this.serversett.willFlag, this.serversett.willTopic, this.serversett.willMessage,
                     this.serversett.cleanSession, this.serversett.keepAlivePeriod);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                this.toolStripStatusLabel_server.BackColor = Color.Red;
                MessageBox.Show(e.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error  " + ex.InnerException != null ? ex.InnerException.Message : "");
            }
        }

        private void button_publish_Click(object sender, EventArgs e)
        {
            if (this.currenttopic != null)
            {
                if (this.currenttopic.Path.Contains("#") || this.currenttopic.Path.Contains("+"))
                    MessageBox.Show("You can't publish on generic topics with wildcards");
                else {
                    try
                    {
                        mqtt.publish(this.currenttopic.Path, this.textBox_message.Text, this.currenttopic.Qos, this.checkBox_retain.Checked);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Select a current topic to publish on");
        }



        string fulltext = "";
        private void DisplayMessage(MqttMessage message)
        {
            string messageformat = string.Format("{0}\t{1}\t{2}\t{3}\r\n", message.Date, message.Topic, (int)message.QosLevel, message.GetStringMessage());

            fulltext = messageformat + (
                (fulltext != null && fulltext.Length > 10000) ?
                fulltext.Substring(0, 1000) : fulltext);
            this.textBox_messagereceived.Text = fulltext;
        }

        private void connecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void déconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mqtt.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DataGridView_topics_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGridView_topics.CurrentRow != null)
            {
                var ct = (MqttTopic)this.dataGridView_topics.CurrentRow.DataBoundItem;
                if (ct != null && (this.currenttopic == null || ct.Path != this.currenttopic.Path))
                {
                    currenttopic = ct;
                    this.label_curernttopic.Text = currenttopic.Path;
                    this.toolStripStatusLabel_curentopic.Text = currenttopic.Path;
                }
            }
        }
        private void DataGridView_topics_CursorChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView_topics_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell c = this.dataGridView_topics.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                MqttTopic t = (MqttTopic)this.dataGridView_topics.Rows[e.RowIndex].DataBoundItem;
                if (t.Subscribed)
                    mqtt.UnSubscribe(t.Path);
                else
                    mqtt.subscribe(t.Path, t.Qos);
                t.Subscribed = !t.Subscribed;
            }
        }
        private void DataGridView_topics_CellValueChanged1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            //change qos
            {
                MqttTopic t = (MqttTopic)this.dataGridView_topics.Rows[e.RowIndex].DataBoundItem;
                if (t.Subscribed)
                {
                    mqtt.UnSubscribe(t.Path);
                    mqtt.subscribe(t.Path, t.Qos);
                }
            }
        }


        private void DataGridView_topics_MouseClick(object sender, MouseEventArgs e)
        {

            //activation du menu contextuel sur la grille des topics
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                int currentMouseOverRow = dataGridView_topics.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    string mess_deletetopic;
                    List<MqttTopic> topicstodelete = new List<MqttTopic>();
                    if (this.dataGridView_topics.SelectedRows.Count > 1)
                    {
                        mess_deletetopic = "Delete selected topics";
                        foreach (var row in this.dataGridView_topics.SelectedRows)
                        {
                            MqttTopic t = (MqttTopic)((DataGridViewRow)row).DataBoundItem;
                            topicstodelete.Add(t);
                        }
                    }
                    else
                    {
                        mess_deletetopic = string.Format("Delete {0}", currenttopic.Path);
                        topicstodelete.Add(currenttopic);
                    }
                    var menu_deletetopics = new MenuItem(mess_deletetopic);
                    menu_deletetopics.Click += (s, ev) =>
                    {
                        foreach (var t in topicstodelete)
                        {
                            if (t.Subscribed && mqtt.IsConnected)
                                mqtt.UnSubscribe(t.Path);
                            this.topics.Remove(t);
                        }
                    };
                    m.MenuItems.Add(menu_deletetopics);
                }
                m.Show(dataGridView_topics, new Point(e.X, e.Y));
            }

        }
        private void testToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.topics.Add(new MqttTopic() { Path = Guid.NewGuid().ToString(), Subscribed = false });

        }

        private void isConnectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mqtt.IsConnected)
                displaystate(false);
        }

        private void cleanReceiveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fulltext = "";
            this.textBox_messagereceived.Clear();
        }


        private void subscribeAllTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var t in topics.Where(a => !a.Subscribed))
            {
                mqtt.subscribe(t.Path, t.Qos);
                t.Subscribed = true;
            }
            this.dataGridView_topics.Refresh();
        }

        private void unsubscribeAllTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //unsubscribe
            foreach (var t in topics.Where(a => a.Subscribed))
            {
                mqtt.UnSubscribe(t.Path);
                t.Subscribed = false;
            }
            this.dataGridView_topics.Refresh();
        }

        private void toolStripMI_addTopic_Click(object sender, EventArgs e)
        {
            string newtopic = this.toolStripTextBoxtopicpath.Text;
            if (!topics.Any(a => a.Path == newtopic))
            {
                byte qos;
                if (byte.TryParse(this.toolStripTextBox_qos.Text, out qos) && qos >= 0 && qos <= 2)
                {
                    MqttTopic t = new MqttTopic() { Path = newtopic, Qos = qos, Subscribed = false };
                    mqtt.AddTopic(t);
                    //mqtt.subscribe(t.Path, t.Qos);
                }
                else
                    MessageBox.Show("the topic QOS must be from 0 to 2 included");
            }
            else
                MessageBox.Show("this topic is already in the topic list");

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MQTT Manager - Simon ANDRE janvier 2016");
        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings(Path.GetFileName(settingsfilepath));
        }

        private void addExistingsettingsToMenu()
        {
            foreach (string settingfilepath in Directory.EnumerateFiles(settingsDirectory))
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(settingfilepath));
                mi.Click += (s, e) =>
                {
                    LoadSettings(Path.GetFileName(settingfilepath));
                };
                this.loadSettingsToolStripMenuItem.DropDownItems.Add(mi);
            }
        }

        private void SaveSettings(string settingfilename)
        {
            SettingsContainer allsettings = new SettingsContainer()
            {
                BrokerSettings = this.serversett,
                Topics = this.topics.ToList()
            };
            if (this.currenttopic != null)
                allsettings.currenttopicpath = this.currenttopic.Path;
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsContainer));
            string settingname = settingfilename.EndsWith(".xml") ? settingfilename : settingfilename + ".xml";
            if (!Directory.Exists(settingsDirectory))
                Directory.CreateDirectory(settingsDirectory);
            string settingspath = Path.Combine(settingsDirectory, settingname);
            using (FileStream fs = new FileStream(settingspath, FileMode.Create))
            {
                serializer.Serialize(fs, allsettings);
            }
        }
        private void PersistsMessages(string messagesfilename, List<MqttMessage> receivedmessages)
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            // XmlSerializer serializer = new XmlSerializer(typeof(List<MqttMessage>));
            using (FileStream fs = new FileStream(messagesfilename, FileMode.Append))
            {
                //serializer.Serialize(fs, receivedmessages);
                formatter.Serialize(fs, receivedmessages);
            }
            receivedmessages.Clear();
        }
        private List<MqttMessage> LoadMessages(string messagesfilename)
        {
            List<MqttMessage> receivedmessages;
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            // XmlSerializer serializer = new XmlSerializer(typeof(List<MqttMessage>));
            using (FileStream fs = new FileStream(messagesfilename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                receivedmessages = (List<MqttMessage>)formatter.Deserialize(fs);
            }
            foreach (var mm in receivedmessages.Take(200))
            {
                this.DisplayMessage(mm);
            }
            return receivedmessages;
        }
        private void LoadSettings(string settingfilename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SettingsContainer));
                string settingspath = Path.Combine(settingsDirectory, settingfilename);
                SettingsContainer allsettings;
                using (FileStream fs = new FileStream(settingspath, FileMode.Open))
                {
                    allsettings = (SettingsContainer)serializer.Deserialize(fs);
                }
                if (allsettings != null)
                {
                    this.topics.Clear();
                    this.serversett = allsettings.BrokerSettings;
                    allsettings.Topics.ForEach(t => this.topics.Add(t));
                    this.currenttopic = allsettings.Topics.FirstOrDefault(a => a.Path == allsettings.currenttopicpath);
                    settingsfilepath = settingspath;
                    //MessageBox.Show(string.Format("Settings correctly loaded from file {0}", settingfilename));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error while loading settings from file {0} : {1}", settingfilename, e.Message));
            }
        }

        private void SaveSettingsAstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = ShowDialog("Save as settings", @"Enter name for the new settings file (It will be located in the MyDocuments\MqttManager Directory)");
            SaveSettings(filename);
        }
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = text,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = caption };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (a, z) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";

        }

        private void inFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string filename = ShowDialog(, @"Enter the name of an XML file to which the incoming messages will be redirected");
            saveFileDialog1.Title = "Redirect messages to file";
            saveFileDialog1.ShowHelp = true;
            saveFileDialog1.HelpRequest += (a, z) =>
        {
            MessageBox.Show(@"Enter name for the new settings file(It will be located in the MyDocuments\MqttManager Directory)");
        };
            var dr = saveFileDialog1.ShowDialog();
            MessagepersistFile = saveFileDialog1.FileName;
        }



        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var of = new OpenFileDialog();
            of.Title = "Choose a persisted message file";
            of.CheckFileExists = true;
            of.ShowDialog();
            string file = of.FileName;
            LoadMessages(file);
        }

        private void batchPublishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int publishwait = 50;
            int nbiteration = 100;
            int.TryParse(this.toolStripTextBox_publishwait.Text, out publishwait);
            int.TryParse(this.toolStripTextBox_numberIterations.Text, out nbiteration);
            if (this.currenttopic != null)
            {
                if (MessageBox.Show(string.Format("Do you want to publish {0} times the current message with {1}ms interval ?", nbiteration, publishwait), "", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < nbiteration; i++)
                    {
                        mqtt.publish(this.currenttopic.Path, string.Format("{0} - {1} - iteration {2}", DateTime.Now.ToString("H:mm:ss"), this.textBox_message.Text, i), this.currenttopic.Qos, false);
                        System.Threading.Thread.Sleep(publishwait);
                    }
                    MessageBox.Show("Batch publication finished");
                }
            }
            else
                MessageBox.Show("Select a current topic to publish on");
        }

        private void sendCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCommand scf = new SendCommand();
            if(scf.ShowDialog(this)== DialogResult.OK){
                SanSensNetProtocol a = new SanSensNetProtocol();
                byte[] buff = a.Encode_SendCommand(scf.CommandId,scf.V1,scf.V2);
                string publishtopic = ConfigurationManager.AppSettings["publishCommands_topic"];
                Console.WriteLine("send commande");
                MqttMessage mess = new MqttMessage(publishtopic, buff, 1, false);
                mqtt.publish(mess);
            }


        }

        private void subscribeEverythingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MqttTopic t = new MqttTopic() { path = "#", qos = 0, subscribed = true };
          mqtt.subscribe("#",0);

        }
    }





}
