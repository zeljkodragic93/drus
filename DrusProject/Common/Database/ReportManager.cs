using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public class ReportManager
    {
        private ScadaEntities _scadaEntites = new ScadaEntities();

        public string GenerateReport1(string meterID, DateTime from, DateTime to)
        {
            StringBuilder ret = new StringBuilder();

            foreach (var meterRead in _scadaEntites.MeterReads)
            {
                if (meterRead.Meter.Name == meterID && (from <= meterRead.Timestamp && to >= meterRead.Timestamp ))
                {
                    ret.AppendFormat("Vrednost: {0}, Vreme ocitavanja: {1}.\n", meterRead.Value, meterRead.Timestamp);
                }
            }
            return ret.ToString();
        }
    }
}
