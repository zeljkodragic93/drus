using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADAService
{
    public delegate void OnMeterRead(double value, string meterID, MeterReadingType readingType);

    public class ScadaServiceHost 
    {
        private ServiceHost _scadaServiceHost = null;
        private ServiceHost _observerHost = null;

        public ScadaServiceHost()
        {

        }

        public bool  InitializeHosts()
        {
            bool ret = false;
            try
            {
                NetTcpBinding bindingScada = new NetTcpBinding();
                string addressScada = "net.tcp://localhost:9998/ScadaService";
                Uri uriScada = new Uri(addressScada);

                WSDualHttpBinding bindingObserver = new WSDualHttpBinding();
                string addressObserver = "http://localhost:9997/ObserverService";
                Uri uriObserver = new Uri(addressScada);

                ObserverService observerService = new ObserverService();
                _observerHost = new ServiceHost(observerService, uriObserver);
                _observerHost.AddServiceEndpoint(typeof(IObserverService), bindingObserver, addressObserver);
                _observerHost.Open();


                ScadaService scadaService = new ScadaService(observerService.OnMeterRead);
                _scadaServiceHost = new ServiceHost(scadaService, uriScada);
                _scadaServiceHost.AddServiceEndpoint(typeof(ISCADAService), bindingScada, addressScada);
                _scadaServiceHost.Open();
                ret = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error occured: {0}.", e.Message));
            }
            return ret;
        }

        public void StopHost()
        {
            if (_scadaServiceHost.State == CommunicationState.Faulted)
            {
                _scadaServiceHost.Abort();
            }
            else
            {
                _scadaServiceHost.Close();
            }

            if (_observerHost.State == CommunicationState.Faulted)
            {
                _observerHost.Abort();
            }
            else
            {
                _observerHost.Close();
            }
        }

    }
}
