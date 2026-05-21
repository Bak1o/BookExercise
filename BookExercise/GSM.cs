using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class GSM
    {
        public string Name { get; set; }
        
        public GSM(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $" GSM name : {Name}";
        }

        public void AddCall(Call call)
        {
            Call.AddCall(call);
        }

        public void RemoveCall(Call call)
        {
            if (!Call.CallHistory.Contains(call))
                throw new ArgumentException(" call was not found");
            Call.CallHistory.Remove(call);
        }
        public void DeleteAllCalls()
        {
            if (Call.CallHistory.Count <= 0)
                throw new ArgumentException(" Call history is empty ");
            Call.CallHistory.Clear();
        }
        public int TotalAmountOfCalls()
        {
            List<Call> list = new List<Call>();
            list = Call.CallHistory;
            return list.Count;

        }


    }
}
