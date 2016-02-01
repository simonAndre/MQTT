using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttClient_handler
{
    [Serializable]
    public class SettingsContainer 
    {
        public serversettings BrokerSettings { get; set; }
        public List<MqttTopic> Topics { get; set; }
        public string currenttopicpath { get; set; }
    }
}
