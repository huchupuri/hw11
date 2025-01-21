using hw10.Classes;
using System;
using hw10.Enums;
using System.Reflection.Metadata;
using hw11.Classes;
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
//        Из класса банковский счет удалить методы, возвращающие значения
//полей номер счета и тип счета, заменить эти методы на свойства только для чтения.
//Добавить свойство для чтения и записи типа string для отображения поля держатель
//банковского счета.Изменить класс BankTransaction, созданный для хранений финансовых
//операций со счетом, - заменить методы доступа к данным на свойства для чтения.
        static void Task1()
        {
            BankAccountFactory factory = new BankAccountFactory();
            uint bankAccount = factory.CreatBankAccount("михаил", 123, AccountType.debit);
            BankAccount account = BankAccountFactory.accounts[bankAccount] as BankAccount;
            Console.WriteLine($"имя: {account.User}, ID: {account.Id}, баланс: {account.Balance}, счет: {account.AccountType} ");
        }
        static void Task2()
        {
            BankAccountFactory factory = new BankAccountFactory();
            uint bankAccount = factory.CreatBankAccount("михаил", 123, AccountType.debit);
            BankAccount account = BankAccountFactory.accounts[bankAccount] as BankAccount;
            account.Deposit(10001);
            account.Deposit(213);
            account.Deposit(543);
            account.WithdrawCash(1000);
            Console.WriteLine(account[3]);

        }
        static void Task3()
        {
            Building[] houses =  
                [
                BuildingCreator.CreateBuild(100, 10), BuildingCreator.CreateBuild(1004, 110), BuildingCreator.CreateBuild(1300, 104), BuildingCreator.CreateBuild(1400, 10),
                BuildingCreator.CreateBuild(1200, 10), BuildingCreator.CreateBuild(1300, 10), BuildingCreator.CreateBuild(100, 130), BuildingCreator.CreateBuild(100, 102),
                BuildingCreator.CreateBuild(100, 10), BuildingCreator.CreateBuild(100, 10)
                ];
            Buildings city = new Buildings(houses);
            Console.WriteLine(city[3]);
        }
    }
}