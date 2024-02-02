using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ConsoleAppTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            InputData inputData = new InputData();
            inputData.InsertTable();

            Console.WriteLine("enter 1 for login and 2 for registration = ");
            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine($"you opt for Login");

                    Console.WriteLine("Enter Email = ");
                    string email = Console.ReadLine();

                    Console.WriteLine("Enter Password = ");
                    string password = Console.ReadLine();

                    Login l = new Login(email, password);
                    l.UserLogin();
                    return;
                }
                else if (choice == 2)
                {
                    Console.WriteLine($"you opt to Register");

                    Console.WriteLine("Enter Name = ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Email = ");
                    string email = Console.ReadLine();

                    Console.WriteLine("Enter Password = ");
                    string password = Console.ReadLine();

                    Console.WriteLine("Enter Phone = ");
                    string phone = Console.ReadLine();

                    Register r = new Register(name, email, password, phone);
                    r.UserRegister();
                    return;
                }

                else
                {
                    Console.WriteLine("enter 1 or 2");
                }
            }

            Console.ReadLine();
        }
    }
}
