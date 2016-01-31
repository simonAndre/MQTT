using Microsoft.VisualStudio.TestTools.UnitTesting;
using sandto1;
using SanSensNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSensNet.Tests
{
    [TestClass()]
    public class SanSensNetProtocolTests
    {
        [TestMethod()]
        public void EncodeDecodePayloadRawTest()
        {
            byte[] inpl = new byte[3];
            inpl[0] = 7;
            inpl[1] = 8;
            inpl[2] = 9;
            SanSensNetProtocol a = new SanSensNetProtocol();
            byte[] encoded = a.EncodePayload(inpl, FrameType.FRCommand);
            Assert.AreEqual(8, encoded.Length);
            int ft;
            var data = a.DecodeRawData(encoded, out ft);
            for (int i = 0; i < inpl.Length; i++)
            {
                Assert.AreEqual(inpl[i], data[i]);
            }
        }
        [TestMethod()]
        public void EncodeDecodeTest()
        {
            SanSensNetProtocol a = new SanSensNetProtocol();
            var comm = a.Encode_SendCommand(5, 45, 2645);
            FrameType fr;
            FrCommand decodedComm = a.DecodeData(comm, out fr) as FrCommand;
            Assert.AreEqual(FrameType.FRCommand, fr);
            Assert.AreEqual(5, decodedComm.cmd);
            Assert.AreEqual(45, decodedComm.v1);
            Assert.AreEqual(2645, decodedComm.v2);
        }
    }
}