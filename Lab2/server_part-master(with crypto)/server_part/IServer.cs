using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_part
{
    interface IServer
    {
        void work();
        void listen();
        void interrapt_work();
    }
}
