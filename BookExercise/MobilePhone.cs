using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class MobilePhone
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int? Price { get; set; }
        public string? Owner { get; set; }
        public Battery BatteryFeatures { get; set; }
        public Display ScreenFeatures { get; set; }
        private static MobilePhone _nokiaN95 = new MobilePhone("N95", "Nokia", 399, "Nokia corp", new Battery("nokiaModel", 50, 7)
            , new Display(4.5, 1200000));
        public static MobilePhone NokiaN95
        {
            get { return _nokiaN95; }
        }
       

        public MobilePhone(string model, string manufacturer, int? price, string? owner, Battery batteryFeatures, Display screenFeatures)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Owner = owner;
            BatteryFeatures = batteryFeatures;
            ScreenFeatures = screenFeatures;
        }
        public MobilePhone(string model, string manufacturer, Battery batteryFeatures, Display screenFeatures)
        : this(model,manufacturer,null,null,batteryFeatures, screenFeatures) 
        {
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Owner: {Owner}");

            BatteryFeatures.PrintInfo();
            ScreenFeatures.PrintInfo();
        }
         public static void PrintNokiaInfo()
        {
            NokiaN95.PrintInfo();
                
        }
       
    }
}
