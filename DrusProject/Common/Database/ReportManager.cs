using Contracts;
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

        public string GenerateReport2(string meterID, int from)
        {
            StringBuilder ret = new StringBuilder();
            foreach (var meterRead in _scadaEntites.MeterReads)
            {
                if (meterRead.Meter.Name == meterID && (from <= meterRead.Value) && meterRead.Type == (int)MeterReadingType.Humidity)
                {
                    ret.AppendFormat("Vrednost: {0}, Vreme ocitavanja: {1}.\n", meterRead.Value, meterRead.Timestamp);
                }
            }
            return ret.ToString();
        }

        public string GenerateReport3(string meterID, int from)
        {
            StringBuilder ret = new StringBuilder();
            foreach (var meterRead in _scadaEntites.MeterReads)
            {
                if (meterRead.Meter.Name == meterID && (from <= meterRead.Value) && meterRead.Type == (int)MeterReadingType.Temeprature)
                {
                    ret.AppendFormat("Vrednost: {0}, Vreme ocitavanja: {1}.\n", meterRead.Value, meterRead.Timestamp);
                }
            }
            return ret.ToString();
        }

        public string GenerateReport4(string meterID)
        {
            StringBuilder ret = new StringBuilder();
            foreach (var meterRead in _scadaEntites.MeterReads)
            {
                double sumT = 0;
                double sumH = 0;
                double noT = 0;
                double noH = 0;
                if (meterRead.Meter.Name == meterID && meterRead.Type == (int)MeterReadingType.Temeprature)
                {
                    sumT = sumT + meterRead.Value;
                    noT++;
                }
                else
                {
                    sumH = sumH + meterRead.Value;
                    noH++;
                }
                ret.AppendFormat("Prosecne vrednosti: \n temperature: {0}, \n Humidity: {1}.\n", sumT / noT, sumH / noH);
            }
            return ret.ToString();
        }
    }
}
