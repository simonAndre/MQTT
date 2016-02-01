using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mqtt
{
    [Serializable]
    public class serversettings:INotifyPropertyChanged
    {
        public serversettings()
        {
            ServerName = "rpi2";
            ClientName = Environment.MachineName;
            ServerPort = 1883;
            //willFlag = true;   
            //willMessage = "sortie";
            //willRetain = true;
            //willTopic = "/will/out";
            willQos = 1;
            UserName = "user";
            Password = "pass";
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(null));

        }

        public string ServerName { get; set; }
        public int ServerPort { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool willRetain { get; set; }
        public byte willQos { get; set; }
        public bool willFlag { get; set; }
        public string willTopic { get; set; }
        public string willMessage { get; set; }
        public bool cleanSession { get; set; }
        public ushort keepAlivePeriod { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
