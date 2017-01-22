using Common.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportManager _reportManager = new ReportManager();

            string menuOption = string.Empty;
            do
            {
                menuOption = PrintMenu();
                if (menuOption == "1")
                {
                    string meterID = string.Empty;
                    DateTime from = DateTime.Now, to = DateTime.Now;
                    MenuOption1(out meterID, out from, out  to);
                    Console.WriteLine(_reportManager.GenerateReport1(meterID, from, to));
                    File.WriteAllText("report.txt", _reportManager.GenerateReport1(meterID, from, to));
                    Console.WriteLine("Uspesno kreirak izvestaj.");
                    Console.ReadLine();

                }
            }
            while (menuOption != "6");

        }

        private static string PrintMenu()
        {
            string option;
            Console.Clear();
            Console.WriteLine("Izaberite opciju:");
            Console.WriteLine("1. Izvestaj za odredjeni merac.");
            Console.WriteLine("2. Izvestaj za odredjeno merenje sa odredjenog meraca.");
            Console.WriteLine("3. Izvestaj trenutaka kada su merenje bila van opsega za odredjeni merac.");
            Console.WriteLine("4. Izvestaj za prosek temperature/vlaznosti za odredjenu lokaciju.");
            Console.WriteLine("5. Izvestaj trenutaaka kada su merenje bila van opsega za odredjenu lokaciju.");
            Console.WriteLine("6. Izlazak iz programa.");
            option = Console.ReadLine();
            return option;
        }

        private static void MenuOption1(out string meterID, out DateTime from, out DateTime to)
        {
            Console.WriteLine("Unesite id meraca:");
            meterID = Console.ReadLine();
            Console.WriteLine("Unesite od kada zelite:");
            from = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesite do kada zelite:");
            to = DateTime.Parse(Console.ReadLine());
        }
    }
}
