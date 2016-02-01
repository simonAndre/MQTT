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
        public event onconnectedHandler OnConnected;
        public event onDisconnectedHandler OnDisconnected;
        public event MqttMessagePublishHandler OnMessageArrived;
        Timer checkconnectiontimer;
        private bool wasConnectedduringLastCheck = false;
        protected BindingList<MqqtTopic> topics = new BindingList<MqqtTopic>();



        public Mqttclient_handler()
        {
            this.checkconnectiontimer = new Timer(CheckServerState, null, 1000, 1000);

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


        public bool MqttConnect(string serveur, string clientid, string username, string password, bool willRetain, byte willQosLevel, bool willFlag, string willTopic, string willMessage, bool cleanSession, ushort keepAlivePeriod)
        {
            // create client instance 
            client = new MqttClient(serveur);
            client.MqttMsgSubscribed += Client_MqttMsgSubscribed;
            client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
            // register to message received 
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            //string clientId = Guid.NewGuid().ToString();
            var res = client.Connect(clientid, username, password, willRetain, willQosLevel, willFlag, willTopic, willMessage, cleanSession, keepAlivePeriod);
            if (OnConnected != null)
                OnConnected(this, new EventArgs());
            return client.IsConnected;
        }

        private void Client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            Console.WriteLine(e.MessageId);
        }

        private void Client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine(e.MessageId);
        }

        public bool MqttConnect(string serveur, string clientid)
        {
            // create client instance 
            client = new MqttClient(serveur);

            // register to message received 
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            //string clientId = Guid.NewGuid().ToString();
            client.Connect(clientid);
            if (OnConnected != null)
                OnConnected(this, new EventArgs());
            return client.IsConnected;
        }


        private void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            MqttMessage m = new MqttMessage(e.Topic, e.Message, e.QosLevel, e.Retain);
            if (OnMessageArrived != null)
                OnMessageArrived(this, new MessPublishEventArgs(m,e.DupFlag));
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

        public void subscribe(string topic, byte qos = MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE)
        {
            client.Subscribe(new string[] { topic }, new byte[] { qos });
        }
        public void UnSubscribe(string topic)
        {
            client.Unsubscribe(new string[] { topic });
        }
        public void publish(string topic, string message, byte qos, bool retain = false)
        {
            client.Publish(topic, Encoding.UTF8.GetBytes(message), qos, retain);
        }
        public void publish(MqttMessage message)
        {
            client.Publish(message.Topic,message.Message,message.QosLevel,message.Retain);
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
