using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttClient_handler
{
    [Serializable]
    public class MqqtTopic
    {
        public MqqtTopic()
        {
            subscribed = false;
            qos = 0;
        }
        public string path { get; set; }
        public bool subscribed { get; set; }
        public byte qos { get; set; }
    }

}
