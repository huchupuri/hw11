using hw10.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace hw10.Classes
{
    internal class BankAccountFactory
    {
        public static Hashtable accounts = new Hashtable();
        public uint CreatBankAccount()
        {
            BankAccount bankAccount = new BankAccount();
            accounts.Add(bankAccount.Id, bankAccount);
            return bankAccount.Id;
        }
        public uint CreatBankAccount(decimal balance)
        {
            BankAccount bankAccount = new BankAccount(balance);
            accounts.Add(bankAccount.Id, bankAccount);
            return bankAccount.Id;
        }

        public uint CreatBankAccount(AccountType? accountType)
        {
            BankAccount bankAccount = new BankAccount(accountType);
            accounts.Add(bankAccount.Id, bankAccount);
            return bankAccount.Id;
        }
        public uint CreatBankAccount(decimal balance, AccountType? accountType)
        {
            BankAccount bankAccount = new BankAccount(balance, accountType);
            accounts.Add(bankAccount.Id, bankAccount);
            return bankAccount.Id;
        }
        public uint CreatBankAccount(string user, decimal balance, AccountType? accountType)
        {
            BankAccount bankAccount = new BankAccount(user, balance, accountType);
            accounts.Add(bankAccount.Id, bankAccount);
            return bankAccount.Id;
        }
        public static void CloseAccount(uint id)
        {
            accounts.Remove(id);
        }
    }
}
