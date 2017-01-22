using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SCADAClient
{
    public class MeterLogic
    {
        private SendToScadaCallback _humidityCallback;
        private SendToScadaCallback _temperatureCallback;

        private string _meterId;
        private Timer _humidityTimer;
        private Timer _temperatureTimer;
        private Random rand = new Random();
        public MeterLogic(string meterId, SendToScadaCallback humidityCallback, SendToScadaCallback temperatureCallback)
        {
            _meterId = meterId;
            _humidityCallback = humidityCallback;
            _temperatureCallback = temperatureCallback;

            _humidityTimer = new Timer();
            _humidityTimer.Interval = 6000;
            _humidityTimer.AutoReset = true;
            _humidityTimer.Elapsed += _humidityTimer_Elapsed;

            _temperatureTimer = new Timer();
            _temperatureTimer.Interval = 1000;
            _temperatureTimer.AutoReset = true;
            _temperatureTimer.Elapsed += _temperatureTimer_Elapsed;
        }
        /// ??
        private void _temperatureTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _temperatureCallback(GenerateTemperature(), _meterId,DateTime.Now);
        }

        private void _humidityTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _humidityCallback(GenerateHumidity(), _meterId, DateTime.Now);
        }

        public void StartMeter()
        {
            _humidityTimer.Start();
            _temperatureTimer.Start();
           
        }

        public int GenerateHumidity()
        {
            return rand.Next(0, 100);
        }

        public float GenerateTemperature()
        {
            return (float)(rand.Next(-20, 40) * rand.NextDouble());
        }


    }
}
