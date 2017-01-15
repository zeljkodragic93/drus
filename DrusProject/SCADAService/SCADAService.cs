using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADAService
{
    public enum MeterReadingType
    {
        Humidity = 0,
        Temeprature
    };

    public class SCADAService : ISCADAService
    {
        DatabaseManager _databaseManager = new DatabaseManager();

        public void SendHumidity(float value, int meterID)
        {
            MeterRead mr = new MeterRead();
            mr.Type = (int)MeterReadingType.Humidity;
            mr.Meter = _databaseManager.GetMeterById(meterID);
            mr.Value = value;
            _databaseManager.AddNewMeterRead(mr);
        }

        public void SendTemperature(float value, int meterID)
        {
            throw new NotImplementedException();
        }
    }
}
