using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using sandto1;

namespace SanSensNet
{


    public enum FrameType
    {
        // trames encodées via nanopb
        FREmontx = 1,
        FRGlcd = 2,
        FRHygTh = 3,
        FRCommand = 4,
        FRSolar = 5,
        FRGatewayStatus = 6,
        FRSetTime = 7
    }

    public class SanSensNetProtocol
    {
        const int PACKETSTARTCODE = 192;
        private UInt16 Checksum(byte[] payload, int start = 0, int length = 0)
        {
            byte sum = 0, sump = 0;
            if (length == 0)
                length = payload.Length;
            for (int i = start; i < (length + start); i++)
            {
                sum += payload[i];
                sump += (byte)((i - start) * payload[i]);
            }
            UInt16 cs = (UInt16)(0 | sum | sump << 8);
            return cs;
        }
        public byte[] EncodePayload(byte[] payload, FrameType frametype)
        {
            int length = payload.Length;
            byte[] encoded = new byte[length + 5];
            var chk = Checksum(payload, 0, length);
            encoded[0] = PACKETSTARTCODE;
            encoded[1] = (byte)frametype;
            encoded[2] = (byte)length;
            int i = 0;
            for (i = 0; i < length; i++)
            {
                encoded[i + 3] = payload[i];
            }
            encoded[i + 3] = (byte)(chk % 256);
            encoded[i + 4] = (byte)(chk / 256);
            return encoded;
        }
        public byte[] Encode_SendCommand(int cmd, int v1, int v2)
        {
            FrCommand comm = new FrCommand()
            {
                cmd = cmd,
                v1 = v1,
                v2 = v2
                ,metadata=new NodeMeta() {  nodeFrom=1, nodeTo=2, rx_rssi=8, Vbatt= 9}
            };
            byte[] buff;
            using (Stream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<FrCommand>(ms, comm);
                buff = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buff, 0, (int)ms.Length);
            }
            return EncodePayload(buff, FrameType.FRCommand);
        }
        public byte[] DecodeRawData(byte[] encodedData, out int frametype)
        {
            frametype = 0;
            if (encodedData[0] == PACKETSTARTCODE)
            {
                byte[] payload;
                frametype = (int)encodedData[1];
                byte length = encodedData[2];
                payload = new byte[length];
                int i = 0;
                for (i = 0; i < length; i++)
                {
                    payload[i] = encodedData[i + 3];
                }
                UInt16 chk = (UInt16)((UInt16)(encodedData[i + 4] * 256) + encodedData[i + 3]);
                UInt16 cchk = Checksum(encodedData, 3, length);
                if (chk != cchk)
                    throw new Exception("Bad checksum");
                return payload;
            }
            return null;
        }

        public object DecodeData(byte[] encodedData, out FrameType frametype)
        {
            int ft;
            byte[] payload = DecodeRawData(encodedData, out ft);
            frametype = (FrameType)ft;

            using (Stream str = new MemoryStream(payload))
            {
                switch (frametype)
                {
                    case FrameType.FREmontx:
                        return Serializer.Deserialize<FrEmontx>(str);
                    case FrameType.FRGlcd:
                        return Serializer.Deserialize<FrGlcd>(str);
                    case FrameType.FRHygTh:
                        return Serializer.Deserialize<FrHygTh>(str);
                    case FrameType.FRCommand:
                        return Serializer.Deserialize<FrCommand>(str);
                    case FrameType.FRSolar:
                        return Serializer.Deserialize<FrSolar>(str);
                    case FrameType.FRGatewayStatus:
                        return Serializer.Deserialize<FrGatewayStatus>(str);
                }
            }
            return null;
        }
    }




    /*
    uint16_t checksum(uint8_t* s, size_t length)
    {
        uint8_t sum = 0, sump = 0;
        for (int i = 0; i < length; i++)
        {
            sum += s[i];
            sump += i * s[i];
        }
        //printf("pour %s:  sum=%i, sump=%i",s,sum,sump);
        uint16_t cs = 0 | sum | sump << 8;
        return cs;
    }*/
}
