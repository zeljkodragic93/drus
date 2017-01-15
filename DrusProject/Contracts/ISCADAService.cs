using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface ISCADAService
    {
        [OperationContract]
        void SendHumidity(float value, int meterID);

        [OperationContract]
        void SendTemperature(float value, int meterID);
    }
}
