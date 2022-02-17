using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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


        INotificationService notification = null;

        public AccountManager()
        {
            notification = new EmailNotificationService();
        }

        public AccountManager(INotificationService service)
        {
            notification = service;
        }
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
            // pin must match
            if (accToWithdraw.Pin != pin)
                throw new IncorrectPinException();
            // should be active account
            if (!accToWithdraw.IsActive)
                throw new InactiveAccountException();
            // sufficcient balance
            if (accToWithdraw.Balance < amount)
                throw new InsufficientBalanceException();
            // should update the balance
            accToWithdraw.Balance -= amount;
            
            notification.Notify($"{accToWithdraw.AccNo} is reduced by {amount}");
           

            return accToWithdraw;
        }

        public bool TransferFound(Account fromAccount, Account toAccount, int amount, int pin)
        {
            return true;
        }

       
    }


    public interface INotificationService
    {
        bool Notify(string msg);
    }

    public class EmailNotificationService : INotificationService
    {
        public bool Notify(string msg)
        {
            SmtpClient smtp = new SmtpClient();
            //smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            //smtp.PickupDirectoryLocation = "e:\\testmails";
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            //smtp.Credentials = new 
            MailMessage mail = new MailMessage("fromaddress@gmail.com", "toaddress@any.com");
            mail.Subject = "Account Transaction Alert";
            mail.Body = msg;

            smtp.Send(mail);
            return true;
        }
    }
}
