using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{

    public enum MeterReadingType
    {
        Humidity = 0,
        Temeprature
    };

    [ServiceContract]
    public interface ISCADAService
    {
        [OperationContract]
        void SendHumidity(float value, string meterID, DateTime timestamp);

        [OperationContract]
        void SendTemperature(float value, string meterID, DateTime timestamp);

        [OperationContract]
        string InitializeClient(string locationName);
    }
}
