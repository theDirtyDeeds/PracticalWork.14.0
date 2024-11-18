using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemExceptions;


namespace PracticalWork_14._0
{
    public class Account
    {
        public string AccountId { get; private set; }
        public decimal Balance { get; protected set; }

        public Account(string accountId)
        {
            AccountId = accountId;
            Balance = 0;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма депозита должна быть положительной.");
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма снятия должна быть положительной.");
            if (amount > Balance) throw new InsufficientFundsException("Недостаточно средств на счете.");
            Balance -= amount;
        }

        public virtual void TransferTo(Account targetAccount, decimal amount)
        {
            Withdraw(amount);
            targetAccount.Deposit(amount);
        }
        public static decimal operator +(Account account, decimal amount)
        {
            return account.Balance + amount;
        }
    }

    public class DepositAccount : Account
    {
        public DepositAccount(string accountNumber) : base(accountNumber) { }

        public override void Withdraw(decimal amount)
        {
            throw new InvalidOperationException("Снятие средств с депозитного счета невозможно.");
        }
    }

    public class NonDepositAccount : Account
    {
        public NonDepositAccount(string accountNumber) : base(accountNumber) { }
    }
    public static class AccountExtensions
    {
        public static void LogAction(this Account account, string action)
        {
            Console.WriteLine($"Действие: {action}, Счет: {account.AccountId}, Баланс: {account.Balance}");
        }
    }
}
