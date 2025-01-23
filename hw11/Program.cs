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
            Task4();
        }
//        Из класса банковский счет удалить методы, возвращающие значения
//полей номер счета и тип счета, заменить эти методы на свойства только для чтения.
//Добавить свойство для чтения и записи типа string для отображения поля держатель
//банковского счета.Изменить класс BankTransaction, созданный для хранений финансовых
//операций со счетом, - заменить методы доступа к данным на свойства для чтения.
        static void Task1()
        {
            Console.WriteLine("задание 1");
            BankAccountFactory factory = new BankAccountFactory();
            uint bankAccount = factory.CreatBankAccount("михаил", 123, AccountType.debit);
            BankAccount account = BankAccountFactory.accounts[bankAccount] as BankAccount;
            Console.WriteLine($"имя: {account.User}, ID: {account.Id}, баланс: {account.Balance}, счет: {account.AccountType} ");
        }
//        Упражнение 13.2 Добавить индексатор в класс банковский счет для получения доступа к
//любому объекту BankTransaction.
        static void Task2()
        {
            Console.WriteLine("задание 2");
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
            Console.WriteLine("задание 3");
            Building house = BuildingCreator.CreateBuild(2, 4, 5, 6);
            Console.WriteLine($"ID: {house.buildingId}, высота: {house.height}, квартиры: {house.apartments}, подъезды: {house.entrances}");
        }
//        Домашнее задание 13.2 Создать класс для нескольких зданий.Поле класса – массив на 10
//зданий.В классе создать индексатор, возвращающий здание по его номеру.
        static void Task4()
        {
            Console.WriteLine("задание 4");
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