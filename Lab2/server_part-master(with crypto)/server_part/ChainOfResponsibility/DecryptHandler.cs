using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_part.ChainOfResponsibility
{
    public class DecryptHandler: Handler
    {
        public override void handle_request(int request, ref ClientInfo client)
        {
            if (request == 1)   //  расшифровка
            {
                Manager manager = new Manager(new CryptoFactory());
                byte[] test = client._buffer.ToArray();
               
                string message = UTF8Encoding.UTF8.GetString(test);
                //Console.WriteLine("Decrypt Hadler received: " + message);

                byte[] decrypted = manager.decrypt64(message);

                //Console.WriteLine(" --- Decrypt Hadler made: " + Encoding.ASCII.GetString(decrypted) + "\n");

                client._buffer.Clear();
                client._buffer.AddRange(decrypted);
            }
           /* else if (successor != null)
                successor.handle_request(request, ref client);*/
        }
    }
}
