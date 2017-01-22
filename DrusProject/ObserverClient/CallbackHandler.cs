using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverClient
{
    public class CallbackHandler : IObseverServiceCallback
    {
        public void SendValue(double value, string meterId, MeterReadingType readingType)
        {
            Console.WriteLine(String.Format("Received reading from meter: {0} with value {1}, type - {2}.", meterId, value, readingType));
        }
    }
}
