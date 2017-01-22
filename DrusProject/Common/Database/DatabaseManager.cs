using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADAService
{
    public class DatabaseManager
    {

        private ScadaEntities _scadaEntites = new ScadaEntities();


        #region Add methods

        public void AddNewLocation(Location location)
        {
            try
            {
                _scadaEntites.Locations.Add(location);
                _scadaEntites.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error occured: {0}.", e.Message));
            }
        }

        public void AddNewMeter(Meter meter)
        {
            try
            {
                _scadaEntites.Meters.Add(meter);
                _scadaEntites.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error occured: {0}.", e.Message));
            }
        }

        public void AddNewMeterRead(MeterRead meterRead)
        {
            try
            {
                _scadaEntites.MeterReads.Add(meterRead);
                _scadaEntites.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error occured: {0}.", e.Message));
            }
        }

        #endregion

        #region Get methods

        public Meter GetMeterById(string MeterId)
        {
            Meter ret = null;
            try
            {
                foreach(var meter in _scadaEntites.Meters )
                {
                    if (meter.Name == MeterId)
                    {
                        ret = meter;
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("Error occured: {0}.", e.Message));
            }
            return ret;
        }

        public int GetLocationIdByName(string locationName)
        {
            int ret = -1;
            foreach(var location in _scadaEntites.Locations)
            {
                if (location.Name == locationName)
                {
                    ret = location.id;
                    break;
                }
            }

            return ret;
        }

        #endregion
    }
}
