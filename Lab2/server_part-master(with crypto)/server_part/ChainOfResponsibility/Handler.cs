using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_part.ChainOfResponsibility
{
    public abstract class Handler
    {
        public void set_successor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void handle_request(int request, ref ClientInfo client);

        protected Handler successor;
    }
}
