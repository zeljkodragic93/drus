using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADAService
{
    class Program
    {
        static void Main(string[] args)
        {
            ScadaServiceHost host = new ScadaServiceHost();

            if (host.InitializeHosts())
            {
                Console.WriteLine("Scada server started!");
            }


            Console.ReadLine();
        }
    }
}
