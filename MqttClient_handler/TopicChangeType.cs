using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttClient_handler
{
    public enum TopicChangeType
    {
        Add,
        /// <summary>
        /// delete a topic
        /// </summary>
        Remove,
        /// <summary>
        /// update in topic properties
        /// </summary>
        Update,
        ClearAll
    }
}
