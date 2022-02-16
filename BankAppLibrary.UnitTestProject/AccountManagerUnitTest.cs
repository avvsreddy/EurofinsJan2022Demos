using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankAppLibrary.UnitTestProject
{
    [TestClass]
    public class AccountManagerUnitTest
    {
        [TestMethod]
        public void Open_WithValidData_ShouldOpenAnAccount()
        {
            AccountManager target = new AccountManager();
            Account actual = target.Open("venkat", 1000, 1234);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Open_WithValidData_ShouldUpdateOpenDate()
        {
            AccountManager target = new AccountManager();
            Account actual = target.Open("venkat", 1000, 1234);
            Assert.AreEqual(DateTime.Now.Date, actual.OpeningDate);
        }

        [TestMethod]
        public void Open_WithValidData_ShouldActivateTheAccount()
        {
            AccountManager target = new AccountManager();
            Account actual = target.Open("venkat", 1000, 1234);
            Assert.AreEqual(true,actual.IsActive);
        }

        [TestMethod]
        public void Close_WithValidData_ShouldCloseTheAccount()
        {
            AccountManager target = new AccountManager();
            Account account = new Account {AccNo = Guid.NewGuid(),Balance = 0, IsActive =true, OpeningDate=DateTime.Now.Date, Name="abcd", Pin=1234 };
            Account closedAcc = target.Close(account);
            Assert.AreEqual(false, closedAcc.IsActive);
        }
        [TestMethod]
        public void Close_WithValidData_ShouldUpdateCloseDate()
        {
            AccountManager target = new AccountManager();
            Account account = new Account { AccNo = Guid.NewGuid(), Balance = 0, IsActive = true, OpeningDate = DateTime.Now.Date, Name = "abcd", Pin = 1234 };
            Account closedAcc = target.Close(account);
            Assert.AreEqual(DateTime.Now.Date, closedAcc.ClosingDate);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void Close_WithInactiveAccount_ShouldThrowException()
        {
            AccountManager target = new AccountManager();
            Account account = new Account { AccNo = Guid.NewGuid(), Balance = 0, IsActive = false, OpeningDate = DateTime.Now.Date, Name = "abcd", Pin = 1234 };
            Account closedAcc = target.Close(account);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountHasBalanceException))]
        public void Close_WithBalance_ShouldThrowException()
        {
            AccountManager target = new AccountManager();
            Account account = new Account { AccNo = Guid.NewGuid(), Balance = 1000, IsActive = true, OpeningDate = DateTime.Now.Date, Name = "abcd", Pin = 1234 };
            Account closedAcc = target.Close(account);
        }
    }
}
