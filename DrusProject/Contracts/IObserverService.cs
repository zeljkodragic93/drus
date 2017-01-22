using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract(SessionMode =SessionMode.Required, CallbackContract = typeof(IObseverServiceCallback))]
    public interface IObserverService
    {

        [OperationContract(IsOneWay = true)]
        void Subscribe(List<string> meterIDs);
    }

    
    public interface IObseverServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendValue(double value, string meterId, MeterReadingType readingType);
    }
}
