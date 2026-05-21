using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Battery
    {
        public string Model { get; set; }
        public TimeSpan IdleTimeInSeconds { get; set; }
        private TimeSpan _talkHours;
        public TimeSpan TalkHours
        {
            get {  return _talkHours; }
            set { _talkHours = value; }
        }
        private BatteryType? _batteryType;
        public BatteryType? BatteryType
        {
            get { return _batteryType; }
            set { _batteryType = value; }
        }

        
        public Battery(string model, int idleTimeInSeconds, double talkhours, BatteryType batteryType)
        {
            Model = model;
            IdleTimeInSeconds = TimeSpan.FromSeconds(idleTimeInSeconds);
            TalkHours = TimeSpan.FromHours(talkhours);
            BatteryType = batteryType;
            
        }

        public Battery(string model, int idleTimeInSeconds, double talkhours) : this (model, idleTimeInSeconds, talkhours,default)
        {
            Model = model;
            IdleTimeInSeconds = TimeSpan.FromSeconds(idleTimeInSeconds);
            TalkHours = TimeSpan.FromHours(talkhours);
           

        }


        public void PrintInfo()
        {
            Console.WriteLine($"battery model : {Model}, idle time {IdleTimeInSeconds}, Talk hours {TalkHours}");
        }
    }
}
