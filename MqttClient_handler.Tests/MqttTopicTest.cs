// <copyright file="MqttTopicTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mqtt;

namespace MqttClient_handler.Tests
{
     [TestClass]
    public partial class MqttTopicTest
    {
    


        [TestMethod]
        public void EqualsTest2()
        {
            MqttTopic obj, target;
            target = new MqttTopic("test/lk", 1, true);
            obj = new MqttTopic("test/lk", 1, true);
            int a = target.GetHashCode();
            int b = obj.GetHashCode();
            Assert.AreEqual(a, b);
            Assert.IsTrue(target.Equals(obj));
            obj = new MqttTopic("test/lk", 2, true);
            Assert.IsFalse(target.Equals(obj));
            obj = new MqttTopic("test/lk1", 1, true);
            Assert.IsFalse(target.Equals(obj));
            obj = new MqttTopic("test/la", 1, true);
            Assert.IsFalse(target.Equals(obj));
            obj = new MqttTopic("test/lk", 1, false);
            Assert.IsFalse(target.Equals(obj));

            // TODO: ajouter des assertions à méthode MqttTopicTest.EqualsTest(MqttTopic, Object)
        }


    }
}
