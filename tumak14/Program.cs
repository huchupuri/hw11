#define DEBUG_ACCOUNT
using hw10.Classes;
using System;
using hw10.Enums;
using System.Reflection.Metadata;
using hw11.Classes;
using hw11.Attributes;

namespace tumak13
{
    class Program()
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
//        Использование предопределенного условного атрибута для условного
//выполнения кода(указывает компиляторам, что при отсутствии символа условной
//компиляции, вызов метода или атрибут следует игнорировать). В классе банковский счет
//добавить метод DumpToScreen, который отображает детали банковского счета.Для
//выполнения этого метода использовать условный атрибут, зависящий от символа условной
//компиляции DEBUG_ACCOUNT.Протестировать метод DumpToScreen.
        static void Task1()
        {
            Console.WriteLine("задание 1");
            BankAccountFactory factory = new BankAccountFactory();
            uint bankAccount = factory.CreatBankAccount(123, AccountType.debit);
            BankAccount account = BankAccountFactory.accounts[bankAccount] as BankAccount;
            account.Deposit(10001);
            account.Deposit(213);
            account.Deposit(543);
            account.WithdrawCash(1000);
            account.DumpToScrean();
        }
        static void Task2()
        {
            Console.WriteLine("\nзадание 2");
            Type type = typeof(RationalNums);

            object[] attributes = type.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);
            foreach (DeveloperInfoAttribute attr in attributes)
            {
                Console.WriteLine($"{attr.DeveloperName} {attr.DevelopmentDate}");
            }
        }
        static void Task3() 
        {
            Console.WriteLine("\nзадание 3");
            Type type = typeof(Building);

            object[] attributes = type.GetCustomAttributes(typeof(DeveloperOrganizationAttribute), false);
            foreach (DeveloperOrganizationAttribute attr in attributes)
            {
                Console.WriteLine($"{attr.DeveloperName} {attr.OrganizationName}");
            }
        }
    }
}