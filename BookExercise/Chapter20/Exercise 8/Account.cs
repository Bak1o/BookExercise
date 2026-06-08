using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20.Exercise_8
{
    internal abstract class Account : IDepositable
    {
        protected Customer Customer { get; set; }
        public decimal Balance { get; protected set; }
        protected double InterestRate { get; set; }
        

        protected Account(Customer customer, decimal balance,
            double interestRate )
        {
            Customer = customer;
            Balance = balance;
            InterestRate = interestRate;
            
        }
      

        public virtual void Deposit(decimal amount)
        {
            if (amount  < 0)
                throw new ArgumentException(amount.ToString());
            Balance += amount;
        }
        public virtual decimal CalculateInterest(int numberOfMonths)
        {
            return (decimal)(numberOfMonths * InterestRate);
        }
        
    }
}
