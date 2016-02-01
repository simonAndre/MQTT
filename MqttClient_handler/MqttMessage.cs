using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mqtt
{
    [Serializable]
    public class MqttMessage
    {
        public MqttMessage()
        {

        }
        public MqttMessage(string topic, byte[] content,byte qos,bool retain)
        {
            Date = DateTime.Now;
            Topic = topic;
            Message = content;
            QosLevel = qos;
            Retain = retain;
            strMessage = GetStringMessage();
        }
        public string Topic { get; set; }
        public bool Retain { get; set; }
        public byte QosLevel { get; set; }
        public byte[] Message { get; set; }
        public string strMessage { get; set; }
        public DateTime Date { get; set; }

        public string GetStringMessage()
        {
            return Encoding.UTF8.GetString(this.Message);
        }
    }

}
