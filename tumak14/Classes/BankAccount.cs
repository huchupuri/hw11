using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using hw10.Enums;
using System.Diagnostics;

namespace hw10.Classes
{
    class BankAccount : IDisposable
    {
        public uint Id { get; private set; }
        public static uint autoID = 0;
        public string User { get; set; }
        public decimal? Balance { get; set; }
        public AccountType? AccountType { get; set; }
        private Queue<BankTransaction> transactions = new Queue<BankTransaction>();
        private bool disposed = false;
        /// <summary>
        /// пустой конструктор 
        /// </summary>
        internal BankAccount()
        {
            Id = GenerateID();
            Balance = null;
            AccountType = null;
        }
        /// <summary>
        /// конструктор с балансом
        /// </summary>
        internal BankAccount(decimal balance)
        {
            Id = GenerateID();
            Balance = balance;
            AccountType = null;
        }

        /// <summary>
        /// конструктор с типом аккаунта
        /// </summary>
        internal BankAccount(AccountType? accountType)
        {
            Id = GenerateID();
            Balance = 0;
            AccountType = accountType;
        }

        /// <summary>
        /// конструктор с типом аккаунта и балансом
        /// </summary>
        internal BankAccount(decimal balance, AccountType? accountType)
        {
            Id = GenerateID();
            Balance = balance;
            AccountType = accountType;
        }
        internal BankAccount(string user, decimal balance, AccountType? accountType)
        {
            User = user;
            Id = GenerateID();
            Balance = balance;
            AccountType = accountType;
        }

        /// <summary>
        /// генерация ID
        /// </summary>
        private uint GenerateID()
        {
            autoID++;
            return autoID;
        }

        /// <summary>
        /// перевод средств
        /// </summary>
        public bool Transfer(BankAccount account, decimal amount)
        {
            if (account.WithdrawCash(amount))
            {
                this.Deposit(amount);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// индексатор
        /// </summary>
        public object this[int index]
        {
            get
            {
                if (index < 0 || index > transactions.LongCount() - 1) return -1;
                Queue<BankTransaction> queueInsert = new Queue<BankTransaction>(transactions);
                for (int i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        return queueInsert.Dequeue();
                    }
                    else queueInsert.Dequeue();
                }
                return null;

            }
            set
            {
            }
        }

        /// <summary>
        /// вывод информации по клиенту
        /// </summary>
        public override string ToString()
        {
            return ($"Номер счета: {Id}, Баланс: {Balance}, Тип счета: {AccountType}\n");
        }

        /// <summary>
        /// снятие денег
        /// </summary>
        public bool WithdrawCash(decimal cash)
        {
            if (cash < 0)
            {
                Console.WriteLine($"сумма должна быть больше 0");
                return false;
            }

            if ((Balance - cash) > 0)
            {
                Balance -= cash;
                AddTransaction(-cash);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// пополнение счета
        /// </summary>
        public void Deposit(decimal cash)
        {
            if (cash <= 0)
            {
                Console.WriteLine("Сумма депозита должна быть больше нуля.");
            }
            Balance += cash;
            AddTransaction(cash);
        }

        /// <summary>
        /// создание транзакции
        /// </summary>
        private void AddTransaction(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(amount);
            transactions.Enqueue(transaction);
        }

        /// <summary>
        /// реализация интерфейса IDisposable
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// переопределение оператора ==
        /// </summary>

        public static bool operator ==(BankAccount bankAccountA, BankAccount bankAccountB)
        {
            return (bankAccountA.Id == bankAccountB.Id);
        }
        /// <summary>
        /// переопределение оператора !=
        /// </summary>
        public static bool operator !=(BankAccount bankAccountA, BankAccount bankAccountB)
        {
            return !(bankAccountA.Id == bankAccountB.Id);
        }
        /// <summary>
        /// переопредельге метода GetHashCode
        /// </summary>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        /// <summary>
        /// переопределние метода Equals
        /// </summary>
        public override bool Equals(object bankAccount)
        {

            if (bankAccount is BankAccount account)
            {
                return this == bankAccount;
            }

            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                using (StreamWriter writer = new StreamWriter("transaction.txt", true))
                {
                    while (transactions.Count > 0)
                    {
                        BankTransaction transaction = transactions.Dequeue();
                        writer.WriteLine($"{transaction.transactionDate} : {transaction.Amount}");
                    }
                }
            }
            disposed = true;
        }

        /// <summary>
        /// выовд информации по транзакциям
        /// </summary>
        [Conditional("DEBUG_ACCOUNT")]
        public void DumpToScrean()
        {
            foreach (BankTransaction item in transactions)
            {
                Console.WriteLine(item);
            }

        }
    }
}
