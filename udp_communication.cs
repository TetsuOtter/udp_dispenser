using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace udp_dispenser
{
    class udp_get
    {
        static public Byte[] GetV()
        {
            IPAddress localAddress = IPAddress.Any;
            int localPort = 9032;
            IPEndPoint localEP = new IPEndPoint(localAddress, localPort);
            UdpClient udp = new UdpClient(localEP);

            IPEndPoint remoteEP = null;
            Byte[] rcvBytes = udp.Receive(ref remoteEP);
            udp.Close();
            return rcvBytes;
        }
        static public void udpsender(string ipadr , string port,Byte[] senddata)
        {
            int portnum = int.Parse(port);
            UdpClient udp = new UdpClient();
            udp.Send(senddata, senddata.Length, ipadr, portnum);
            udp.Close();
        }
    }
}
