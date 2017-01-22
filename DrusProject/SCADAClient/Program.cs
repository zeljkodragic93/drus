using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADAClient
{
    class Program
    {
        private static ScadaClient _client;
        private static MeterLogic _logic;
        static void Main(string[] args)
        {
            InitializeClient();
            string id = string.Empty;

            if (File.Exists("uniqueId.txt"))
            {
                id = File.ReadAllLines("uniqueId.txt")[0];
            }
            else
            {
                id =  _client.InitializeClient(args[0]);
                File.WriteAllText("uniqueId.txt", id);
            }

            _logic = new MeterLogic(id, _client.SendHumidity, _client.SendTemperature);

            _logic.StartMeter();
            Console.ReadLine();
        }


        public static void InitializeClient()
        {
            string endpointAddress = "net.tcp://localhost:9998/ScadaService";
            EndpointAddress address = new EndpointAddress(endpointAddress);
            NetTcpBinding binding = new NetTcpBinding();
            _client = new ScadaClient(binding, address);
            _client.Open();

            Console.WriteLine("Client initialized!");
        }
    }
}
