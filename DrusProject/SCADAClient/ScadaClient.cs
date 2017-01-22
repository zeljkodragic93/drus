using Contracts;
using SCADAClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace SCADAClient
{
    public delegate void SendToScadaCallback(float value, string meterId,DateTime timestamp);

    public class ScadaClient : ClientBase<ISCADAService>, ISCADAService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScadaClient"/> class.
        /// </summary>
        public ScadaClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScadaClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Endpoint configuration name.</param>
        public ScadaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ScadaClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Endpoint configuration name.</param>
        /// <param name="remoteAddress">Remote address.</param>
        public ScadaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScadaClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Endpoint configuration name.</param>
        /// <param name="remoteAddress">Remote address.</param>
        public ScadaClient(string endpointConfigurationName, EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScadaClient"/> class.
        /// </summary>
        /// <param name="binding">Binding of WCF communication.</param>
        /// <param name="remoteAddress">Remote address.</param>
        public ScadaClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public string InitializeClient(string locationName)
        {
            return Channel.InitializeClient(locationName);
        }

        public void SendHumidity(float value, string meterID, DateTime timestamp)
        {
            Channel.SendHumidity(value, meterID, timestamp);
        }


        public void SendTemperature(float value, string meterID, DateTime timestamp)
        {
            Channel.SendTemperature(value, meterID,timestamp);
        }
    }
}
