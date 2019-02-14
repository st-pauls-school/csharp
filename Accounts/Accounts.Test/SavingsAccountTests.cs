using System.Linq;
using Accounts.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Accounts.Test
{
    [TestClass]
    public class SavingsAccountTests
    {
        IAccount _savingsAccount;
        const decimal INTERESTRATE = 0.015m;

        [TestInitialize]
        public void CreateAccountToShare()
        {
            _savingsAccount = new SavingsAccount(INTERESTRATE);
        }

        [TestMethod]
        public void TestSavingsAccount()
        {
            Assert.AreEqual("Savings Account, 1.5% interest, annually", _savingsAccount.AccountInfo);
            Assert.AreEqual(false, _savingsAccount.CanGoOverdrawn);
        }

        [TestMethod]
        public void TestCreditTransaction()
        {
            decimal before = _savingsAccount.Balance;
            int numBefore = _savingsAccount.Transactions.Count();
            ITransaction credit = new Transaction(TransactionType.Credit, "Birthday Monday", 25.0);

            Assert.AreEqual(TransactionType.Credit, credit.Type);
            Assert.AreEqual(25.0m, credit.Value);
            Assert.AreEqual("Birthday Money", credit.Description);

            decimal after = _savingsAccount.Balance;
            Assert.AreEqual(before + 25, _savingsAccount.Balance);
            Assert.AreEqual(numBefore + 1, _savingsAccount.Transactions.Count());
        }

        [TestMethod]
        public void TestInterestTransaction()
        {
            decimal before = _savingsAccount.Balance;
            _savingsAccount.ApplyInterest();
            Assert.AreEqual(before * (1 + INTERESTRATE), _savingsAccount.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(OverdrawnException))]
        public void TestOverdrawn()
        {
            decimal before = _savingsAccount.Balance;
            ITransaction debit = new Transaction(TransactionType.Debit, "Reckless Spending", before * 2);
            Assert.AreEqual(-before, _savingsAccount.Balance);
        }
    }
}
