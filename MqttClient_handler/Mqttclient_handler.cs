using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace mqtt
{



    public class Mqttclient_handler : IDisposable
    {
        private MqttClient client = null;
        public delegate void onconnectedHandler(Mqttclient_handler sender, EventArgs e);
        public delegate void onDisconnectedHandler(Mqttclient_handler sender, EventArgs e);
        public delegate void MqttMessagePublishHandler(Mqttclient_handler sender, MessPublishEventArgs e);
        public delegate void TopicListHandler(Mqttclient_handler sender, TopicChangeEventArgs e);
        public event onconnectedHandler OnConnected;
        public event onDisconnectedHandler OnDisconnected;
        public event MqttMessagePublishHandler OnMessageArrived;
        public event TopicListHandler OnTopicChange;
        Timer checkconnectiontimer;
        private bool wasConnectedduringLastCheck = false;
        public Dictionary<string, MqttTopic> _topics = new Dictionary<string, MqttTopic>();

        //test

        public Mqttclient_handler()
        {
            this.checkconnectiontimer = new Timer(CheckServerState, null, 1000, 1000);
        }
        
        public bool MqttConnect(string serveur, string clientid, string username=null, string password=null, bool willRetain=false, byte willQosLevel=1, bool willFlag=false, string willTopic=null, string willMessage=null, bool cleanSession=true, ushort keepAlivePeriod=60)
        {
            // create client instance 
            client = new MqttClient(serveur);
            client.MqttMsgSubscribed += Client_MqttMsgSubscribed;
            client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
            // register to message received 
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            //string clientId = Guid.NewGuid().ToString();
            if (username != null)
            {
                if (willFlag)
                    client.Connect(clientid, username, password, willRetain, willQosLevel, willFlag, willTopic, willMessage, cleanSession, keepAlivePeriod);
                else
                    client.Connect(clientid, username, password);
            }
            else
                client.Connect(clientid);


            if (OnConnected != null)
                OnConnected(this, new EventArgs());
            return client.IsConnected;
        }

        public IEnumerable<MqttTopic> SubscribedTopics
        {
            get
            {
                return _topics.Where(t => t.Value.Subscribed).Select(t => t.Value);
            }
        }


        public MqttTopic GetTopic(string topicPath)
        {
            if (_topics != null && _topics.ContainsKey(topicPath))
                return _topics[topicPath];
            return null;
        }
        public void ClearTopics()
        {
            foreach (var topic in _topics)
            {
                RemoveTopic(topic.Key);
            }
        }
        public void AddTopic(MqttTopic topic)
        {
            if (!_topics.ContainsKey(topic.Path))
            {
                _topics.Add(topic.Path, topic);
                if (OnTopicChange != null)
                    OnTopicChange(this, new TopicChangeEventArgs(topic, TopicChangeType.Add));
                topic.PropertyChanged += Topic_PropertyChanged;
            }
        }

        private void Topic_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Qos":
                    if (OnTopicChange != null)
                        OnTopicChange(this, new TopicChangeEventArgs(sender as MqttTopic, TopicChangeType.Update));
                    break;
                case "Subscribed":
                    if (((MqttTopic)sender).Subscribed)
                        client.Subscribe(new string[] { ((MqttTopic)sender).Path }, new byte[] { ((MqttTopic)sender).Qos });
                    else
                        client.Unsubscribe(new string[] { ((MqttTopic)sender).Path });

                    if (OnTopicChange != null)
                        OnTopicChange(this, new TopicChangeEventArgs(sender as MqttTopic, TopicChangeType.Update));
                    break;
                case "Path":
                    break;
                default:
                    break;
            }
        }

        public void RemoveTopic(string topicpath)
        {
            if (_topics.ContainsKey(topicpath))
            {
                var oldtopic = _topics[topicpath];
                oldtopic.PropertyChanged -= Topic_PropertyChanged;
                _topics.Remove(topicpath);
                if (OnTopicChange != null)
                    OnTopicChange(this, new TopicChangeEventArgs(oldtopic, TopicChangeType.Remove));
            }
        }

        private void CheckServerState(object state)
        {
            if (wasConnectedduringLastCheck && !IsConnected)
            {
                // le serveur n'est plus accessible
                wasConnectedduringLastCheck = false;
                if (OnDisconnected != null)
                    OnDisconnected(this, new EventArgs());
            }
            else if (IsConnected)
                wasConnectedduringLastCheck = true;
        }


      

        private void Client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            Console.WriteLine(e.MessageId);
        }

        private void Client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine(e.MessageId);
        }

      


        private void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            MqttMessage m = new MqttMessage(e.Topic, e.Message, e.QosLevel, e.Retain);
            var t = new MqttTopic(e.Topic, e.QosLevel, true);
            AddTopic(t);

            if (OnMessageArrived != null)
                OnMessageArrived(this, new MessPublishEventArgs(m, e.DupFlag));
        }

        public bool Disconnect()
        {
            if (this.client != null)
            {
                if (this.client.IsConnected)
                {
                    this.client.Disconnect();
                    if (OnDisconnected != null)
                        OnDisconnected(this, new EventArgs());
                }
                return !this.client.IsConnected;
            }
            return false;
        }
        public bool IsConnected
        {
            get
            {
                return client != null && client.IsConnected;
            }
        }
        public void subscribe(MqttTopic topic)
        {
            var knowtopic = GetTopic(topic.Path);
            if (knowtopic == null || !knowtopic.Subscribed)
            {
                topic.Subscribed = true;
            }
        }

        public void subscribe(string topic, byte qos = MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE)
        {
            MqttTopic to = new MqttTopic(topic, qos, true);
            subscribe(to);
        }

        public void UnSubscribe(string topic)
        {
            var thetopic = GetTopic(topic);
            if (thetopic != null && thetopic.Subscribed)
            {
                thetopic.Subscribed = false;
            }
        }

     
        public void publish(string topic, string message, byte qos, bool retain = false)
        {
            client.Publish(topic, Encoding.UTF8.GetBytes(message), qos, retain);
        }

        public void publish(MqttMessage message)
        {
            client.Publish(message.Topic, message.Message, message.QosLevel, message.Retain);
        }







        #region IDisposable Support
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés).
                }
                if (this.client != null)
                {
                    if (this.client.IsConnected)
                        this.client.Disconnect();
                    this.client = null;
                }
                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~Mqtt() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }

}
