using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace BankAppLibrary.UnitTestProject
{
    [TestClass]
    public class AccountManagerUnitTest
    {
        AccountManager target = null;
        Account acc = null;
        [TestInitialize]
        public void Init()
        {
            target = new AccountManager();
            acc = new Account
            {
                AccNo = Guid.NewGuid(),
                Balance = 1000,
                IsActive = true,
                Name = "customer name",
                OpeningDate = DateTime.Now.AddYears(-1),
                Pin = 1234
            };
        }

        [TestCleanup]
        public void Clean()
        {
            target = null;
            acc = null;
        }

        [TestMethod]
        public void Open_WithValidData_ShouldOpenAnAccount()
        {
            //AccountManager target = new AccountManager();
            Account actual = target.Open("venkat", 1000, 1234);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Open_WithValidData_ShouldUpdateOpenDate()
        {
            //AccountManager target = new AccountManager();
            Account actual = target.Open("venkat", 1000, 1234);
            Assert.AreEqual(DateTime.Now.Date, actual.OpeningDate);
        }

        [TestMethod]
        public void Open_WithValidData_ShouldActivateTheAccount()
        {
            //AccountManager target = new AccountManager();
            Account actual = target.Open("venkat", 1000, 1234);
            Assert.AreEqual(true,actual.IsActive);
        }

        [TestMethod]
        public void Close_WithValidData_ShouldCloseTheAccount()
        {
            //AccountManager target = new AccountManager();
            Account account = new Account {AccNo = Guid.NewGuid(),Balance = 0, IsActive =true, OpeningDate=DateTime.Now.Date, Name="abcd", Pin=1234 };
            Account closedAcc = target.Close(account);
            Assert.AreEqual(false, closedAcc.IsActive);
        }
        [TestMethod]
        public void Close_WithValidData_ShouldUpdateCloseDate()
        {
            //AccountManager target = new AccountManager();
            Account account = new Account { AccNo = Guid.NewGuid(), Balance = 0, IsActive = true, OpeningDate = DateTime.Now.Date, Name = "abcd", Pin = 1234 };
            Account closedAcc = target.Close(account);
            Assert.AreEqual(DateTime.Now.Date, closedAcc.ClosingDate);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void Close_WithInactiveAccount_ShouldThrowException()
        {
            //AccountManager target = new AccountManager();
            Account account = new Account { AccNo = Guid.NewGuid(), Balance = 0, IsActive = false, OpeningDate = DateTime.Now.Date, Name = "abcd", Pin = 1234 };
            Account closedAcc = target.Close(account);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountHasBalanceException))]
        public void Close_WithBalance_ShouldThrowException()
        {
            //AccountManager target = new AccountManager();
            Account account = new Account { AccNo = Guid.NewGuid(), Balance = 1000, IsActive = true, OpeningDate = DateTime.Now.Date, Name = "abcd", Pin = 1234 };
            Account closedAcc = target.Close(account);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPinException))]
        public void Withdraw_WithIncorrectPin_ShouldThrowExp()
        {
            target.Withdraw(acc, 100, 5678);
        }

        [TestMethod]
        [ExpectedException(typeof(InactiveAccountException))]
        public void Withdraw_WithInactiveAccount_ShouldThrowExp()
        {
            acc.IsActive = false;
            target.Withdraw(acc, 1000, 1234);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientBalanceException))]
        public void Withdraw_WithInsufficientBalance_ShouldThrowExp()
        {
            target.Withdraw(acc, 2000, 1234);
        }

        [TestMethod]
      
        public void Withdraw_WithValidAccount_ShouldUpdateBalance()
        {
            // target = new AccountManager(new DummyNotificationService());
            Mock<INotificationService> mock = new Mock<INotificationService>();
            mock.Setup(m => m.Notify(null)).Returns(true);
            target = new AccountManager(mock.Object);
            target.Withdraw(acc, 500, 1234);
            Assert.AreEqual(500, acc.Balance);
        }
    }

    //class DummyNotificationService : INotificationService
    //{
    //    public bool Notify(string msg)
    //    {
    //        return true;
    //    }
    //}
}
