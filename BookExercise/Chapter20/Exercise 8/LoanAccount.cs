using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20.Exercise_8
{
    internal class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, double interestRate) 
            : base(customer, balance, interestRate)
        {
        }
        public override decimal CalculateInterest(int numberOfMonths)
        {
            if ((Customer is Individual && numberOfMonths <= 3)
            || (Customer is Company && numberOfMonths <= 2))
                return 0;

            return base.CalculateInterest(numberOfMonths);
        }
       
    }
}
