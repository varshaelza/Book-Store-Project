﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varsha_BankingLIB
{
    public class Savings:Accounts
    {
        #region Constructors
        public Savings(int p_accNo,string p_accName,double p_accBalance,bool p_accIsactive):base(p_accNo,p_accName,p_accBalance,p_accIsactive)
        { 

        }
        #endregion

        #region Methods
        public override bool Withdraw(double amount)
        {
            if (amount > 10000)
            {
                Console.WriteLine("Unable to process request as maximum withdrawal amount is 10000");
                return false;
            }
            else
            {
                return base.Withdraw(amount);
            }
            
        }
        public override bool Deposit(double amount)
        {
            if (amount > 50000)
            {
                Console.WriteLine("Unable to process request as maximum deposit amount is 50000");
                return false;
            }
            else
            {
                return base.Deposit(amount);
            }
            
        }
        #endregion
    }
}
