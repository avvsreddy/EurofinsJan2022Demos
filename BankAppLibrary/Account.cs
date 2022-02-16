using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppLibrary
{
    public  class Account
    {
        public Guid AccNo { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Pin { get; set; }
        public bool IsActive { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        // accno, name, balance, pin number, isActive openingDate and 
        //closingDate
    }

    public class AccountManager
    {
        // opening, closing, withdraw, deposits and transfer
        public Account Open(string name, int amount, int pin)
        {
            Account account = new Account();
            account.AccNo = Guid.NewGuid();
            account.Name = name;
            account.Balance = amount;
            account.Pin = pin;
            account.OpeningDate = DateTime.Now.Date;
            account.IsActive = true;
            return account;
        }

        public Account Close(Account accToClose)
        {
            if (!accToClose.IsActive)
                throw new AccountAlreadyClosedException();
            if (accToClose.Balance > 0)
                throw new AccountHasBalanceException();

            accToClose.IsActive = false;
            accToClose.ClosingDate = DateTime.Now.Date;
            return accToClose;
        }

        public Account Deposit(Account accToDeposit, int amount)
        {
            return accToDeposit;
        }

        public Account Withdraw(Account accToWithdraw, int amount, int pin)
        {
            return accToWithdraw;
        }

        public bool TransferFound(Account fromAccount, Account toAccount, int amount, int pin)
        {
            return true;
        }
    }
}
