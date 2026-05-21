using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class GSMTest
    {
        public static List<GSM> GSMList { get; } = new List<GSM>();

        public GSMTest(GSM gSM)
        {
            GSMList.Add(gSM);
        }
        public static void AddGSM(GSM gSM)
        {
            GSMList.Add(gSM);
        }

        public static void PrintGSMsInfo()
        {
            foreach (GSM gSM in GSMList)
            {
                Console.WriteLine(gSM.ToString());
            }
        }
        public static void PrintNokiaInfo()
        {
            MobilePhone.NokiaN95.PrintInfo();
        }
    }
}
