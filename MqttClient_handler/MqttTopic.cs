using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mqtt
{
    [Serializable]
    public class MqttTopic : INotifyPropertyChanged
    {
        private string _path;
        private bool _subscribed;
        private byte _qos;


        public MqttTopic()
        {
            Subscribed = false;
            Qos = 0;
        }
        public MqttTopic(string path, byte qos, bool subscribed = false)
        {
            this.Path = path;
            Subscribed = subscribed;
            Qos = qos;
        }
        public string Path
        {
            get { return _path; }
            set
            {
                if (value != _path)
                {
                    _path = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Path"));
                }
            }
        }
        public bool Subscribed
        {
            get { return _subscribed; }
            set
            {
                if (value != _subscribed)
                {
                    _subscribed = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Subscribed"));
                }
            }
        }
        public byte Qos
        {
            get { return _qos; }
            set
            {
                if (value != _qos)
                {
                    _qos = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Qos"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void UpdateTopic( MqttTopic newtopic)
        {
            this.Path = newtopic.Path;
            this.Qos = newtopic.Qos;
            this.Subscribed = newtopic.Subscribed;
        }


        public override int GetHashCode()
        {
            return Path.GetHashCode() ^ Subscribed.GetHashCode() ^ Qos.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
    }



  
}
