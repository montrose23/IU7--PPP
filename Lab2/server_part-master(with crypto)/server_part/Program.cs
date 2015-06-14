using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_part
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerManager server_manager = new ServerManager(11000, Console.Out);

            server_manager.start_work();
        }
    }
}
