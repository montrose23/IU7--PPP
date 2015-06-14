using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_part.ChainOfResponsibility
{
    public class ResendHandler: Handler //  лучше оставить отправку менеджеру
    {
        public override void handle_request(int request, ref ClientInfo client)
        {
            if (request == 4)   //  отправка
            {
                if (client._buffer.Count > 0)
                {
                    ;
                }
            }
          /*  else if (successor != null)
                successor.handle_request(request, ref client);*/
        }
    }
}
