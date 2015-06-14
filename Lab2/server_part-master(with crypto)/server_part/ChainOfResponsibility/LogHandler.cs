using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_part.ChainOfResponsibility
{
    public class LogHandler: Handler
    {
        public override void handle_request(int request, ref ClientInfo client)
        {
            if (request == 2)   //  логирование
            {
                ;
            }
           /* else if (successor != null)
                successor.handle_request(request, ref client);*/
        }
    }
}
