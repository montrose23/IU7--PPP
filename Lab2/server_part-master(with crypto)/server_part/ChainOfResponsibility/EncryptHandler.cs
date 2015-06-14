using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace server_part.ChainOfResponsibility
{
    public class EncryptHandler: Handler
    {
        public override void handle_request(int request, ref ClientInfo client)
        {
            if (request == 3)   //  зашифровка
            {
                Manager manager = new Manager(new CryptoFactory());
                byte[] message = client._buffer.ToArray();

                //string test = UTF8Encoding.UTF8.GetString(message);
                //Console.WriteLine("Encrypt Hadler received: " + test);

                string encoded = manager.encrypt64(message);
                //Console.WriteLine(" --- Encrypt Handler made: " + encoded + "\n");

                List<byte> newMessage = new List<byte>();
                newMessage = UTF8Encoding.UTF8.GetBytes(encoded).ToList<byte>();
                client._buffer.Clear();
                client._buffer.AddRange(newMessage); 
            }
           /* else if (successor != null)
                successor.handle_request(request, ref client);*/
        }
    }
}
