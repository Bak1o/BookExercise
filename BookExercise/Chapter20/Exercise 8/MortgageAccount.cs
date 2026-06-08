using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20.Exercise_8
{
    internal class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, double interestRate) 
            : base(customer, balance, interestRate)
        {
        }
        public override decimal CalculateInterest(int numberOfMonths)
        {
            if (Customer is Company && numberOfMonths <= 12)
                return base.CalculateInterest(numberOfMonths) * 0.5m;
            if (Customer is Individual && numberOfMonths <= 6)
                return default;
            return base.CalculateInterest(numberOfMonths);
        }
        
    }
}
