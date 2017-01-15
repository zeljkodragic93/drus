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

        public Meter GetMeterById(int MeterId)
        {
            Meter ret = null;
            try
            {
                ret = _scadaEntites.Meters.Find(MeterId);
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("Error occured: {0}.", e.Message));
            }
            return ret;
        }

        #endregion
    }
}
