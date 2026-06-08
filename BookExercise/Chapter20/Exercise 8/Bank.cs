using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20.Exercise_8
{
    internal class Bank
    {
        public readonly List<Account> Accounts;
        public Bank()
        {
            Accounts = new List<Account>();
        }
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
    }
}
