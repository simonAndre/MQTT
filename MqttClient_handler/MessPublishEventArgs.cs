using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttClient_handler
{
    public class MessPublishEventArgs : EventArgs
    {
        public MessPublishEventArgs(MqttMessage message, bool dupFlag)
        {
            this.Message = message;
            this.DupFlag = dupFlag;
        }


        public MqttMessage Message { get; set; }

        public bool DupFlag { get; set; }
    }
}
