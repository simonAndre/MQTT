using mqtt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace mqttclient
{
   
    class Program
    {




        static void Main(string[] args)
        {
            string serveur = ConfigurationManager.AppSettings["mqttserveur"];
            string clientid = ConfigurationManager.AppSettings["clientid"];
            string topicsStr = ConfigurationManager.AppSettings["topics"];
            //Dictionary<string, string> topicNames = new Dictionary<string, string>();
            Dictionary<string, List<MqttMessage>> messagesByTopic = new Dictionary<string, List<MqttMessage>>();
            //List<MqttMessage> messages = new List<MqttMessage>();
            Mqttclient_handler mqtt = new Mqttclient_handler();
            mqtt.MqttConnect(serveur, clientid);
            foreach (var tokv in topicsStr.Split(';'))
            {
                string topicname = tokv.Split('=')[0];
                string topicvalue = tokv.Split('=')[1];
                mqtt.subscribe(topicvalue, 0);
               // topicNames.Add(topicvalue, topicname);
            }


            Console.WriteLine("mqtt isconnected : {0}", mqtt.IsConnected);
            mqtt.OnMessageArrived += (Mqttclient_handler sender, MessPublishEventArgs e) =>
            {
                Console.WriteLine("at {0} from {1} : {2}", e.Message.Date, e.Message.Topic, e.Message.GetStringMessage());
                if (!messagesByTopic.ContainsKey(e.Message.Topic))
                    messagesByTopic.Add(e.Message.Topic, new List<MqttMessage>());
                messagesByTopic[e.Message.Topic].Add(e.Message);
                if (messagesByTopic[e.Message.Topic].Count > 20)
                {
                    SaveMessages(messagesByTopic[e.Message.Topic], e.Message.Topic, FileType.csv);
                    messagesByTopic[e.Message.Topic].Clear();
                }
            };
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey();
                if (k.KeyChar == 'w')
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
                    Console.WriteLine("Messages saved ");
                }
                //Console.WriteLine("press [Esc] to quit, [w] to write messages on disc");
            } while (true);// (k.Key != ConsoleKey.Escape);
            mqtt.Dispose();
        }

        public enum FileType
        {
            xml,
            bin,
            csv
        }
        public static void SaveMessages(List<MqttMessage> messages, string filename, FileType filetype = FileType.bin, string directory = null)
        {
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
                            string ligne = mm.Date + ";" + mm.strMessage+"\r\n";
                            var buff = Encoding.UTF8.GetBytes(ligne);
                            fs.Write(buff,0,buff.Length);
                        }
                        fs.Flush();
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
