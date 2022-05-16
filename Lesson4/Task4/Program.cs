using System;
using System.CodeDom;
using System.IO;
using Yar.Learning;
using static System.Console;

namespace Task4
{
    public struct Account
    {
        private string _login;
        private string _password;
        public static Account CreatePair(string login, string password)
        {
            Account newPair = new Account();
            newPair._login = login;
            newPair._password = password;
            return newPair;
        }
        public static bool Check(Account account1, Account account2)
        {
            if ((account1._login == account2._login) && (account1._password == account2._password))
                return true;
            else
                return false;
        }
        public static Account CreatePairFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();
            StreamReader sr = new StreamReader(fileName);
            var baseAccount = new string [2]; 
            baseAccount[0] = sr.ReadLine();
            baseAccount[1] = sr.ReadLine();
            sr.Close();
            return CreatePair(baseAccount[0], baseAccount[1]);
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Реализовать ДЗ 2 урока через структуру и считать логин-пароль из файла");
            WriteLine();
            string filename = AppDomain.CurrentDomain.BaseDirectory + "baseAccount.txt";
            Account baseAccount = Account.CreatePairFromFile(filename);
            
            int numberOfAttempts = 3;
            Account userInput = new Account();

            while (true)
            {
                if (numberOfAttempts == 0)
                {
                    WriteLine("You triggered a massive explosion!");
                    OutputSamples.Explosion();
                    return;
                }
                WriteLine("Attempts left: {0}",numberOfAttempts);
                WriteLine("Login: ");
                string userLogin = ReadLine();
                WriteLine("Password: ");
                string userPassword = ReadLine();
                userInput = Account.CreatePair(userLogin, userPassword);
                if (!Account.Check(baseAccount, userInput))
                {
                    numberOfAttempts--;
                    Clear();
                }
                else break;
            }
            WriteLine("Valid");
                
                


        }
    }
}