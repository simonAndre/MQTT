using mqtt;
using SanSensNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Topshelf;

namespace mqttService
{
    public class mqttservice : ServiceControl, IDisposable
    {
        string serveur;
        string clientid;
        string topicsStr;
        Dictionary<string, List<MqttMessage>> messagesByTopic;
        Mqttclient_handler mqtt;
        Timer timer_persistIncomingMessages;
        Timer timer_sendCommand;
        public mqttservice()
        {
            serveur = ConfigurationManager.AppSettings["mqttserveur"];
            clientid = ConfigurationManager.AppSettings["clientid"];
            topicsStr = ConfigurationManager.AppSettings["topics"];
            messagesByTopic = new Dictionary<string, List<MqttMessage>>();
        }
        public bool Start(HostControl hc)
        {
            bool r = Start();
            return r;
        }
        public bool Start()
        {
            mqtt = new Mqttclient_handler();
            
            mqtt.MqttConnect(serveur, clientid);
            foreach (var tokv in topicsStr.Split(';'))
            {
                string topicname = tokv.Split('=')[0];
                string topicvalue = tokv.Split('=')[1];
                mqtt.subscribe(topicvalue, 0);
                // topicNames.Add(topicvalue, topicname);
            }
            int writeperiod = int.Parse(ConfigurationManager.AppSettings["writeperiod"]);
            int sendperiod = int.Parse(ConfigurationManager.AppSettings["sendperiod"]);
            timer_persistIncomingMessages = new Timer(WriteMessages, null, 0, writeperiod * 1000);
            timer_sendCommand = new Timer(SendMessages, null, 0, sendperiod * 1000);
            // Console.WriteLine("mqtt isconnected : {0}", mqtt.IsConnected);
            mqtt.OnMessageArrived += (Mqttclient_handler sender, MessPublishEventArgs e) =>
            {
                Console.WriteLine("at {0} from {1} : {2}", e.Message.Date, e.Message.Topic, e.Message.GetStringMessage());
                if (!messagesByTopic.ContainsKey(e.Message.Topic))
                    messagesByTopic.Add(e.Message.Topic, new List<MqttMessage>());
                messagesByTopic[e.Message.Topic].Add(e.Message);
                if (messagesByTopic[e.Message.Topic].Count > 1000)
                {
                    SaveMessages(messagesByTopic[e.Message.Topic], e.Message.Topic, FileType.csv);
                    messagesByTopic[e.Message.Topic].Clear();
                }
            };
            return true;
            /*  do
               {
                   Thread.Sleep(50);
               } while (true);*/
        }
        public bool Stop(HostControl hc)
        {
            return Stop();
        }
        public bool Stop()
        {
            mqtt.Dispose();
            timer_persistIncomingMessages.Dispose();
            timer_persistIncomingMessages = null;
            return true;
        }

        public void WriteMessages(object state)
        {
            foreach (var topic in messagesByTopic.Keys)
            {
                try
                {
                    if (messagesByTopic[topic] != null && messagesByTopic[topic].Any())
                        SaveMessages(messagesByTopic[topic], topic, FileType.csv);
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Error in serialization topic {0}", topic), e);
                }
            }
            messagesByTopic.Clear();
        }
        public void SendMessages(object state)
        {
            Console.WriteLine("send commande");
            SanSensNetProtocol a = new SanSensNetProtocol();
            byte[] buff = a.Encode_SendCommand(7, 54, 215);
            string publishtopic = ConfigurationManager.AppSettings["publishCommands_topic"];
            MqttMessage mess = new MqttMessage(publishtopic, buff, 1, false);
            mqtt.publish(mess);
        }


        public enum FileType
        {
            xml,
            bin,
            csv
        }
        public static void SaveMessages(List<MqttMessage> messages, string filename, FileType filetype = FileType.bin, string directory = null)
        {
            Console.WriteLine("Persistence des message reçus");
            filename = filename.Replace('/', '_');
            if (directory == null)
                directory = ConfigurationManager.AppSettings["workingDirectory"];

            if (directory == ".")
                directory = Environment.CurrentDirectory;
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            switch (filetype)
            {
                case FileType.xml:
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(List<MqttMessage>));
                    filename = filename.EndsWith(".xml") ? filename : filename + ".xml";
                    using (FileStream fs = new FileStream(Path.Combine(directory, filename), FileMode.Append))
                    {
                        xmlserializer.Serialize(fs, messages);
                    }
                    break;
                case FileType.bin:
                    filename = filename.EndsWith(".bin") ? filename : filename + ".bin";
                    IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    using (FileStream fs = new FileStream(Path.Combine(directory, filename), FileMode.Append))
                    {
                        formatter.Serialize(fs, messages);
                    }
                    break;
                case FileType.csv:
                    filename = filename.EndsWith(".csv") ? filename : filename + ".csv";
                    using (FileStream fs = new FileStream(Path.Combine(directory, filename), FileMode.Append))
                    {
                        foreach (var mm in messages)
                        {
                            string ligne = mm.Date + ";" + mm.strMessage + "\r\n";
                            var buff = Encoding.UTF8.GetBytes(ligne);
                            fs.Write(buff, 0, buff.Length);
                        }
                        fs.Flush();
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            if (timer_persistIncomingMessages != null)
            {
                timer_persistIncomingMessages.Dispose();
                timer_persistIncomingMessages = null;
            }
            if (mqtt != null)
                mqtt.Dispose();
        }
    }
}
