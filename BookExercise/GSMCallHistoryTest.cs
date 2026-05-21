using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class GSMCallHistoryTest
    {
        public string GetGSMOperator(GSM gSM)
        {
            return gSM.ToString();
        }
        public void AddCall(Call call, GSM gsm)
        {
            gsm.AddCall(call);
        }
        public void DisplayCallInfo(Call call)
        {
            call.PrintInfo();
        }
        public void CalculateCostOfCall(Call call, double price)
        {
            double cost = (call.Duration.TotalSeconds / 60) * price;
            Console.WriteLine($" the cost of call with {call.Duration} is {cost}");
        }
        public void DisplayCallHistory()
        {
            Call.PrintCallHistoryInfo();
        }
        public void CalculateTotalCost(double minuteCost)
        {
            List<Call> calls = Call.CallHistory;
            double totalCost = 0;
            foreach (Call call in calls)
            {
                totalCost = totalCost + (call.Duration.TotalSeconds / 60 * minuteCost);
            }

            Console.WriteLine($"Cost of all calls is : {totalCost}");
        }

        public void RemoveLongestCall()
        {
            List<Call> calls = Call.CallHistory;
            double maxDuration = 0;
            int index = -1;
            for (int i = 0; i < calls.Count; i++)
            {
                if (calls[i].Duration.TotalSeconds > maxDuration)
                {
                    maxDuration = calls[i].Duration.TotalSeconds;
                    index = i;

                }
            }

            if (index == -1)
                throw new ArgumentException(" the call history is empty ");

            Call.RemoveCall(calls[index]);
        }

        public void ClearCallHistory()
        {
            Call.ClearHistory();
        }


            
        
    }
}
