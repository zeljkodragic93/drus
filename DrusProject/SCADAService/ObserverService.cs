using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADAService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ObserverService : IObserverService
    {
        /// <summary>
        /// Key - client callback.
        /// Value - List of subscribed meters.
        /// </summary>
        private Dictionary<IObseverServiceCallback, List<string>> _clientMetersDict = new Dictionary<IObseverServiceCallback, List<string>>();

        public void Subscribe(List<string> meterIDs)
        {
            _clientMetersDict.Add(OperationContext.Current.GetCallbackChannel<IObseverServiceCallback>(), meterIDs);
        }

        public void OnMeterRead(double value, string meterID, MeterReadingType readingType)
        {
            foreach (var kvPair in _clientMetersDict)
            {
                if(kvPair.Value.Contains(meterID))
                {
                    kvPair.Key.SendValue(value, meterID,readingType);
                }
            }
        }
    }
}
