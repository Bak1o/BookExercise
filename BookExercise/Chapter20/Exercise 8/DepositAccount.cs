using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20.Exercise_8
{
    internal class DepositAccount : Account, IWithdrawable
    {
        public DepositAccount(Customer customer, decimal balance, double interestRate) 
            : base(customer, balance, interestRate)
        {
        }
        public override decimal CalculateInterest(int numberOFMonths)
        {
            if (Balance >= 0 && Balance < 1000)
                return 0;
            return base.CalculateInterest(numberOFMonths);
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new ArgumentException("There is no enough money");
            if (amount < 0)
                throw new ArgumentException(" Pleace enter right amount");
            Balance -= amount;
        }
    }
}
