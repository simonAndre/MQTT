using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mqtt
{
    public class TopicChangeEventArgs : EventArgs
    {
        public TopicChangeEventArgs(MqttTopic topic, TopicChangeType changetype)
        {
            this.Topic = topic;
            this.ChangeType = changetype;
        }
        public MqttTopic Topic { get; set; }
        public TopicChangeType ChangeType { get; set; }
    }
}
