using Common;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADAService
{



    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class ScadaService : ISCADAService
    {
        private DatabaseManager _databaseManager = new DatabaseManager();

        private OnMeterRead _onMeterReadCallback;

        public ScadaService(OnMeterRead onMeterReadCallback)
        {
            _onMeterReadCallback = onMeterReadCallback;
        }

        public string InitializeClient(string locationName)
        {
            int locationId = _databaseManager.GetLocationIdByName(locationName);

            if (locationId == -1)
            {
                throw new FaultException("Location does not exist.");
            }
            Meter m = new Meter();
            m.Location_ID = locationId;

            // Generise jedinstven string.
            m.Name = Guid.NewGuid().ToString();
            _databaseManager.AddNewMeter(m);
            return m.Name;
        }

        public void SendHumidity(float value, string meterID, DateTime timestamp)
        {
            MeterRead mr = new MeterRead();
            mr.Type = (int)MeterReadingType.Humidity;
            mr.Meter = _databaseManager.GetMeterById(meterID);
            mr.Value = value;
            mr.Timestamp = timestamp;
            _databaseManager.AddNewMeterRead(mr);
            _onMeterReadCallback(value, meterID, MeterReadingType.Humidity);
        }

        public void SendTemperature(float value, string meterID, DateTime timestamp)
        {
            MeterRead mr = new MeterRead();
            mr.Type = (int)MeterReadingType.Temeprature;
            mr.Meter = _databaseManager.GetMeterById(meterID);
            mr.Value = value;
            mr.Timestamp = timestamp;
            _databaseManager.AddNewMeterRead(mr);
            _onMeterReadCallback(value, meterID, MeterReadingType.Temeprature);
        }

    }
}
