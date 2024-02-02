using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ConsoleAppTask1
{
    internal class Register
    {
        private string name;
        private string email;
        private string password;
        private string phone;

        public Register(string name, string email, string password, string phone)
        {
            this.name = InputValidData(name, @"^[a-zA-Z]+$", "Invalid name format");
            this.email = InputValidData(email, @"^[a-zA-Z0-9_\-\.]+@[a-z]+[\.][a-z]{2,3}$", "Invalid email format");
            this.password = InputValidData(password, @"^[a-z0-9]+$", "Invalid password format");
            this.phone = InputValidData(phone, @"^\d{10}$", "Invalid phone number format");
        }

        public string InputValidData(string input, string regex, string errorMessage)
        {
            string inputData = input;

            Regex reg = new Regex(regex);

            if (reg.IsMatch(inputData))
            {
                return inputData;
            }

            Console.WriteLine(errorMessage);
            return "invalid format";
        }

        public void UserRegister()
        {
            if (InsertUser(name, email, password, phone) > 0)
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Registration failed. Please try again.");
            }

            Console.ReadLine();
        }

        static int InsertUser(string name, string email, string password, string phone)
        {
            if(name == "invalid format" || email == "invalid format" || password == "invalid format" || phone == "invalid format")
            {
                return 0;
            }

            string conn = ConfigurationManager.ConnectionStrings["CreateConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                string query = $"INSERT INTO Registration_Form (Name, Email, Password, Phone) VALUES " +
                               $"('{name}', '{email}', '{password}', '{phone}')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
