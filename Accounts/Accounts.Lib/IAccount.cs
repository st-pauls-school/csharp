using System;
using System.Collections.Generic;

namespace Accounts.Lib
{
    public interface IAccount
    {
        string AccountInfo { get; }
        void ApplyTransaction(ITransaction transaction);
        decimal Balance { get; }
        void ApplyInterest();
        IEnumerable<ITransaction> Transactions { get; }
        bool CanGoOverdrawn { get; }
    }

    public interface ITransaction
    {
        decimal Value { get; }
        TransactionType Type { get; }
        string Description { get; }
        DateTime Timestamp { get; }
    }

    public enum TransactionType
    {
        Credit, 
        Interest,  // Credit and Interest are values that are added to the balance 
        Debit,
        Charge // Debit and Charge are values that are taken from the balance 
    }
}
