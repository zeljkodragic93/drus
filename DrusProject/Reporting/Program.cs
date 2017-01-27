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
                    Console.WriteLine("Uspesno kreiran izvestaj.");
                    Console.ReadLine();

                }
                if (menuOption == "2")
                {
                    string meterID = string.Empty;
                    int from = 0;
                    MenuOption2(out meterID, out from);
                    Console.WriteLine(_reportManager.GenerateReport2(meterID, from));
                    File.WriteAllText("report1.txt", _reportManager.GenerateReport2(meterID, from));
                    Console.WriteLine("Uspesno kreiran izvestaj.");
                    Console.ReadLine();
                }
                if (menuOption == "3")
                {
                    string meterID = string.Empty;
                    int from = 0;
                    MenuOption3(out meterID, out from);
                    Console.WriteLine(_reportManager.GenerateReport3(meterID, from));
                    File.WriteAllText("report2.txt", _reportManager.GenerateReport3(meterID, from));
                    Console.WriteLine("Uspesno kreiran izvestaj.");
                    Console.ReadLine();
                }
                if (menuOption == "4")
                {
                    string meterID = string.Empty;
                    int from = 0;
                    MenuOption4(out meterID);
                    Console.WriteLine(_reportManager.GenerateReport4(meterID));
                    File.WriteAllText("report3.txt", _reportManager.GenerateReport4(meterID));
                    Console.WriteLine("Uspesno kreiran izvestaj.");
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
            Console.WriteLine("2. Izvestaj za trenutke kada su mjeranja temperatura bila veca od odredjene vlaznosti.");
            Console.WriteLine("3. Izvestaj za trenutaka kada su merenje vlaznosti bila veca od odredjene temperature.");
            Console.WriteLine("4. Izvestaj za prosek temperature/vlaznosti za odredjenu lokaciju.");
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
        private static void MenuOption2(out string meterID, out int from)
        {
            Console.WriteLine("Unesite id meraca");
            meterID = Console.ReadLine();
            Console.WriteLine("Unesite vlaznost:");
            from = int.Parse(Console.ReadLine());
        }
        private static void MenuOption3(out string meterID, out int from)
        {
            Console.WriteLine("Unesite id meraca");
            meterID = Console.ReadLine();
            Console.WriteLine("Unesite temperaturu:");
            from = int.Parse(Console.ReadLine());
        }

        private static void MenuOption4(out string meterID)
        {
            Console.WriteLine("Unesite id meraca");
            meterID = Console.ReadLine();
        }
    }
}
