namespace MQTT
{
    partial class MqttWinclient
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.button_publish = new System.Windows.Forms.Button();
            this.textBox_messagereceived = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_server = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_curentopic = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serveurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.déconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSettingsAstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanReceiveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.inFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPersistedMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchPublishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_numberIterations = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox_publishwait = new System.Windows.Forms.ToolStripTextBox();
            this.topicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxtopicpath = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox_qos = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMIAddTopic = new System.Windows.Forms.ToolStripMenuItem();
            this.subscribeAllTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsubscribeAllTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isConnectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanSensNetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGrid3 = new System.Windows.Forms.PropertyGrid();
            this.dataGridView_topics = new System.Windows.Forms.DataGridView();
            this.checkBox_retain = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_curernttopic = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_topics)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Message";
            // 
            // textBox_message
            // 
            this.textBox_message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_message.Location = new System.Drawing.Point(7, 44);
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(661, 135);
            this.textBox_message.TabIndex = 8;
            // 
            // button_publish
            // 
            this.button_publish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_publish.Location = new System.Drawing.Point(550, 0);
            this.button_publish.Name = "button_publish";
            this.button_publish.Size = new System.Drawing.Size(124, 23);
            this.button_publish.TabIndex = 10;
            this.button_publish.Text = "Publish this message";
            this.button_publish.UseVisualStyleBackColor = true;
            this.button_publish.Click += new System.EventHandler(this.button_publish_Click);
            // 
            // textBox_messagereceived
            // 
            this.textBox_messagereceived.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_messagereceived.Location = new System.Drawing.Point(0, 19);
            this.textBox_messagereceived.Name = "textBox_messagereceived";
            this.textBox_messagereceived.Size = new System.Drawing.Size(674, 248);
            this.textBox_messagereceived.TabIndex = 11;
            this.textBox_messagereceived.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_server,
            this.toolStripStatusLabel_curentopic});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1009, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_server
            // 
            this.toolStripStatusLabel_server.Name = "toolStripStatusLabel_server";
            this.toolStripStatusLabel_server.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel_server.Text = "Serveur";
            // 
            // toolStripStatusLabel_curentopic
            // 
            this.toolStripStatusLabel_curentopic.Name = "toolStripStatusLabel_curentopic";
            this.toolStripStatusLabel_curentopic.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel_curentopic.Text = "topic";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serveurToolStripMenuItem,
            this.messagesToolStripMenuItem,
            this.topicsToolStripMenuItem,
            this.testToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.sanSensNetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1009, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serveurToolStripMenuItem
            // 
            this.serveurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connecterToolStripMenuItem,
            this.déconnecterToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveSettingsToolStripMenuItem,
            this.SaveSettingsAstoolStripMenuItem,
            this.loadSettingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitterToolStripMenuItem});
            this.serveurToolStripMenuItem.Name = "serveurToolStripMenuItem";
            this.serveurToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serveurToolStripMenuItem.Text = "Server";
            // 
            // connecterToolStripMenuItem
            // 
            this.connecterToolStripMenuItem.Name = "connecterToolStripMenuItem";
            this.connecterToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.connecterToolStripMenuItem.Text = "Connect";
            this.connecterToolStripMenuItem.Click += new System.EventHandler(this.connecterToolStripMenuItem_Click);
            // 
            // déconnecterToolStripMenuItem
            // 
            this.déconnecterToolStripMenuItem.Name = "déconnecterToolStripMenuItem";
            this.déconnecterToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.déconnecterToolStripMenuItem.Text = "Disconnect";
            this.déconnecterToolStripMenuItem.Click += new System.EventHandler(this.déconnecterToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveSettingsToolStripMenuItem.Text = "save settings";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // SaveSettingsAstoolStripMenuItem
            // 
            this.SaveSettingsAstoolStripMenuItem.Name = "SaveSettingsAstoolStripMenuItem";
            this.SaveSettingsAstoolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.SaveSettingsAstoolStripMenuItem.Text = "Save settings as";
            this.SaveSettingsAstoolStripMenuItem.Click += new System.EventHandler(this.SaveSettingsAstoolStripMenuItem_Click);
            // 
            // loadSettingsToolStripMenuItem
            // 
            this.loadSettingsToolStripMenuItem.Name = "loadSettingsToolStripMenuItem";
            this.loadSettingsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadSettingsToolStripMenuItem.Text = "load settings";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.quitterToolStripMenuItem.Text = "Quit";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // messagesToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanReceiveListToolStripMenuItem,
            this.toolStripMenuItem2,
            this.loadPersistedMessageToolStripMenuItem,
            this.batchPublishToolStripMenuItem});
            this.messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.messagesToolStripMenuItem.Text = "Messages";
            // 
            // cleanReceiveListToolStripMenuItem
            // 
            this.cleanReceiveListToolStripMenuItem.Name = "cleanReceiveListToolStripMenuItem";
            this.cleanReceiveListToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.cleanReceiveListToolStripMenuItem.Text = "clean received messages list";
            this.cleanReceiveListToolStripMenuItem.Click += new System.EventHandler(this.cleanReceiveListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inFileToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 22);
            this.toolStripMenuItem2.Text = "Persist received messages";
            // 
            // inFileToolStripMenuItem
            // 
            this.inFileToolStripMenuItem.Name = "inFileToolStripMenuItem";
            this.inFileToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.inFileToolStripMenuItem.Text = "in file";
            this.inFileToolStripMenuItem.Click += new System.EventHandler(this.inFileToolStripMenuItem_Click);
            // 
            // loadPersistedMessageToolStripMenuItem
            // 
            this.loadPersistedMessageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem});
            this.loadPersistedMessageToolStripMenuItem.Name = "loadPersistedMessageToolStripMenuItem";
            this.loadPersistedMessageToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.loadPersistedMessageToolStripMenuItem.Text = "Load persisted message";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.fromFileToolStripMenuItem.Text = "from file";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.fromFileToolStripMenuItem_Click);
            // 
            // batchPublishToolStripMenuItem
            // 
            this.batchPublishToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_numberIterations,
            this.toolStripTextBox_publishwait});
            this.batchPublishToolStripMenuItem.Name = "batchPublishToolStripMenuItem";
            this.batchPublishToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.batchPublishToolStripMenuItem.Text = "batch publish";
            this.batchPublishToolStripMenuItem.Click += new System.EventHandler(this.batchPublishToolStripMenuItem_Click);
            // 
            // toolStripTextBox_numberIterations
            // 
            this.toolStripTextBox_numberIterations.Name = "toolStripTextBox_numberIterations";
            this.toolStripTextBox_numberIterations.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_numberIterations.Text = "200";
            this.toolStripTextBox_numberIterations.ToolTipText = "number of iterations";
            // 
            // toolStripTextBox_publishwait
            // 
            this.toolStripTextBox_publishwait.Name = "toolStripTextBox_publishwait";
            this.toolStripTextBox_publishwait.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_publishwait.Text = "50";
            this.toolStripTextBox_publishwait.ToolTipText = "wait between 2 publish in ms";
            // 
            // topicsToolStripMenuItem
            // 
            this.topicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTopicToolStripMenuItem,
            this.subscribeAllTopicsToolStripMenuItem,
            this.unsubscribeAllTopicsToolStripMenuItem});
            this.topicsToolStripMenuItem.Name = "topicsToolStripMenuItem";
            this.topicsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.topicsToolStripMenuItem.Text = "Topics";
            // 
            // addTopicToolStripMenuItem
            // 
            this.addTopicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxtopicpath,
            this.toolStripTextBox_qos,
            this.toolStripMIAddTopic});
            this.addTopicToolStripMenuItem.Name = "addTopicToolStripMenuItem";
            this.addTopicToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addTopicToolStripMenuItem.Text = "add topic";
            // 
            // toolStripTextBoxtopicpath
            // 
            this.toolStripTextBoxtopicpath.Name = "toolStripTextBoxtopicpath";
            this.toolStripTextBoxtopicpath.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxtopicpath.Text = "/";
            this.toolStripTextBoxtopicpath.ToolTipText = "topic path";
            // 
            // toolStripTextBox_qos
            // 
            this.toolStripTextBox_qos.Name = "toolStripTextBox_qos";
            this.toolStripTextBox_qos.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_qos.Text = "1";
            this.toolStripTextBox_qos.ToolTipText = "topic QOS";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMIAddTopic.Name = "toolStripMenuItem1";
            this.toolStripMIAddTopic.Size = new System.Drawing.Size(160, 22);
            this.toolStripMIAddTopic.Text = "Add this topic";
            this.toolStripMIAddTopic.Click += new System.EventHandler(this.toolStripMIAddTopic_Click);
            // 
            // subscribeAllTopicsToolStripMenuItem
            // 
            this.subscribeAllTopicsToolStripMenuItem.Name = "subscribeAllTopicsToolStripMenuItem";
            this.subscribeAllTopicsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.subscribeAllTopicsToolStripMenuItem.Text = "subscribe all topics";
            this.subscribeAllTopicsToolStripMenuItem.Click += new System.EventHandler(this.subscribeAllTopicsToolStripMenuItem_Click);
            // 
            // unsubscribeAllTopicsToolStripMenuItem
            // 
            this.unsubscribeAllTopicsToolStripMenuItem.Name = "unsubscribeAllTopicsToolStripMenuItem";
            this.unsubscribeAllTopicsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.unsubscribeAllTopicsToolStripMenuItem.Text = "Un-subscribe all topics";
            this.unsubscribeAllTopicsToolStripMenuItem.Click += new System.EventHandler(this.unsubscribeAllTopicsToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isConnectedToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.testToolStripMenuItem.Text = "test";
            // 
            // isConnectedToolStripMenuItem
            // 
            this.isConnectedToolStripMenuItem.Name = "isConnectedToolStripMenuItem";
            this.isConnectedToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.isConnectedToolStripMenuItem.Text = "is connected";
            this.isConnectedToolStripMenuItem.Click += new System.EventHandler(this.isConnectedToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.aboutToolStripMenuItem.Text = "about";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // sanSensNetToolStripMenuItem
            // 
            this.sanSensNetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendCommandToolStripMenuItem});
            this.sanSensNetToolStripMenuItem.Name = "sanSensNetToolStripMenuItem";
            this.sanSensNetToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.sanSensNetToolStripMenuItem.Text = "SanSensNet";
            // 
            // sendCommandToolStripMenuItem
            // 
            this.sendCommandToolStripMenuItem.Name = "sendCommandToolStripMenuItem";
            this.sendCommandToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sendCommandToolStripMenuItem.Text = "Send Command";
            this.sendCommandToolStripMenuItem.Click += new System.EventHandler(this.sendCommandToolStripMenuItem_Click);
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid3.Location = new System.Drawing.Point(3, 25);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(323, 301);
            this.propertyGrid3.TabIndex = 16;
            // 
            // dataGridView_topics
            // 
            this.dataGridView_topics.AllowUserToAddRows = false;
            this.dataGridView_topics.AllowUserToResizeRows = false;
            this.dataGridView_topics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_topics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_topics.Location = new System.Drawing.Point(3, 18);
            this.dataGridView_topics.Name = "dataGridView_topics";
            this.dataGridView_topics.Size = new System.Drawing.Size(323, 130);
            this.dataGridView_topics.TabIndex = 21;
            // 
            // checkBox_retain
            // 
            this.checkBox_retain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_retain.AutoSize = true;
            this.checkBox_retain.Location = new System.Drawing.Point(478, 3);
            this.checkBox_retain.Name = "checkBox_retain";
            this.checkBox_retain.Size = new System.Drawing.Size(66, 20);
            this.checkBox_retain.TabIndex = 22;
            this.checkBox_retain.Text = "Retain";
            this.checkBox_retain.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Received messages :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_curernttopic);
            this.panel1.Controls.Add(this.textBox_message);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBox_retain);
            this.panel1.Controls.Add(this.button_publish);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 204);
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Current topic : ";
            // 
            // label_curernttopic
            // 
            this.label_curernttopic.AutoSize = true;
            this.label_curernttopic.Location = new System.Drawing.Point(81, 24);
            this.label_curernttopic.Name = "label_curernttopic";
            this.label_curernttopic.Size = new System.Drawing.Size(18, 16);
            this.label_curernttopic.TabIndex = 23;
            this.label_curernttopic.Text = " - ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1009, 491);
            this.splitContainer1.SplitterDistance = 676;
            this.splitContainer1.TabIndex = 25;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.textBox_messagereceived);
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Size = new System.Drawing.Size(676, 491);
            this.splitContainer3.SplitterDistance = 204;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.propertyGrid3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView_topics);
            this.splitContainer2.Size = new System.Drawing.Size(329, 491);
            this.splitContainer2.SplitterDistance = 336;
            this.splitContainer2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "MQTT client and broker configuration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Topics list";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // MqttWinclient
            // 
            this.ClientSize = new System.Drawing.Size(1009, 537);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MqttWinclient";
            this.Text = "MqttManager -S.Andre  jan 2016";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_topics)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Button button_publish;
        private System.Windows.Forms.RichTextBox textBox_messagereceived;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_server;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serveurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connecterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem déconnecterToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid3;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_topics;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isConnectedToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_retain;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanReceiveListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTopicToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxtopicpath;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_qos;
        private System.Windows.Forms.ToolStripMenuItem subscribeAllTopicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsubscribeAllTopicsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIAddTopic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_curernttopic;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_curentopic;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SaveSettingsAstoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem inFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem loadPersistedMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchPublishToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_numberIterations;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_publishwait;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem sanSensNetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendCommandToolStripMenuItem;
    }
}

