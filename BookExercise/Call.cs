using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Call
    {
        public MobilePhone Phone { get; set; }
        public DateOnly Date { get; }
        public TimeOnly StartTime { get; }
        public TimeSpan Duration { get; }
        public static List<Call> CallHistory { get; } = new List<Call>();
        public Call(MobilePhone phone, double durationMinute)
        {
            Phone = phone;
            Duration = TimeSpan.FromMinutes(durationMinute);
            Date = DateOnly.FromDateTime(DateTime.Now);
            StartTime = TimeOnly.FromDateTime(DateTime.Now);
            

        }

        public void PrintInfo()
        {
            Console.WriteLine($" phone : {Phone.Model}");
            Console.WriteLine($" Date call was made : {Date.ToString()}");
            Console.WriteLine($" call started at {StartTime}");
            Console.WriteLine($" call duration {Duration.ToString()}  ");
        }
        public static void AddCall(Call call)
        {
            CallHistory.Add(call);
        }

        public static void PrintCallHistoryInfo()
        {
            Console.WriteLine(" call history : ");
            foreach (Call call in CallHistory)
            {
                Console.WriteLine($" call to {call.Phone.Manufacturer}");

            }
        }

        public void RemoveFromCallFromHistory()
        {
            CallHistory.Remove(this);
        }
        public static void RemoveCall(Call call)
        {
            CallHistory.Remove(call);
        }
        public static void ClearHistory()
        {
            CallHistory.Clear();
        }
    }
}
