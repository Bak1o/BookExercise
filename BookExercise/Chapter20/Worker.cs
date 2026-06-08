using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal sealed class Worker : Human, IComparable<Worker>
    {
        public  decimal Wage {  get; private set; }
        public  int HoursWorked { get; private set; }
        public Worker(string firstName,string lastName, decimal wage, int hoursWorked) : base(firstName, lastName)
        {
            Wage = wage;
            HoursWorked = hoursWorked;
        }
        public decimal GetHourlyWage
        {
            get
            {
                return CalculateHourlyWage();
            }
        }
        public void UpdateWage(decimal wage)
        {
            Wage = wage;
        }
        public void UpdateHoursWorked(int hours)
        {
            HoursWorked = hours;
        }

        private decimal CalculateHourlyWage()
        {
            if (HoursWorked == 0)
                throw new InvalidOperationException("worked hours Can not be zero");
            return Wage / HoursWorked;
        }

        public int CompareTo(Worker? other)
        {
            if (other is null)
                return 1;
            return Wage.CompareTo(other.Wage);
        }
        public override string ToString()
        {
            return $" {base.FirstName} {base.LastName} Salary : {Wage}";
        }
    }
}
