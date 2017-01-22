using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverClient
{
    class Program
    {
        private static ObserverClient _client;
        static void Main(string[] args)
        {
            string[] meters = args[0].Split(',');

            InitializeClient();

            List<string> meterIds = new List<string>();
            foreach(string meter in meters)
            {
                meterIds.Add(meter);
            }

            _client.Subscribe(meterIds);
            while(true)
            {
                Thread.Sleep(1000);
            }
        }

        private static void InitializeClient()
        {
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

            WSDualHttpBinding bindingObserver = new WSDualHttpBinding();
            string addressObserver = "http://localhost:9997/ObserverService";
            EndpointAddress address = new EndpointAddress(addressObserver);
            _client = new ObserverClient(instanceContext, bindingObserver, address);
            _client.Open();

            Console.WriteLine("Client initialized!");
        }


    }
}
