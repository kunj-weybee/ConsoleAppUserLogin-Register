using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleAppTask1
{
    internal class InputData
    {
        public void InsertTable()
        {
            string conn = ConfigurationManager.ConnectionStrings["CreateConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                //string name = InputValidData("Enter name: ", @"^[a-zA-Z]+$", "Invalid name format");

                //string email = InputValidData("Enter email: ", @"^[a-zA-Z0-9_\-\.]+@[a-z]+[\.][a-z]{2,3}$", "Invalid email format");

                //string phone = InputValidData("Enter phone (10 digits only): ", @"^\d{10}$", "Invalid phone number format");

                //string password = InputValidData("Enter password (small letters and numbers only): ", @"^[a-z0-9]+$", "Invalid password format");



                //SqlCommand cmd = new SqlCommand($"INSERT INTO Registration_Form (name, email, password, phone) VALUES ({name}, {email}, {password}, {phone})", con);

                //cmd.ExecuteNonQuery();


                string[] names = { "Aman", "Chaman", "Kavya", "Minal", "Mohan" };
                string[] emails = { "aman@example.com", "chaman@example.com", "kavya@example.com", "minal@example.com", "mohan@example.com" };
                string[] phones = { "1234567890", "9876543210", "5551234567", "8765432109", "3210987654" };
                string[] passwords = { "aman123", "chaman456", "kavya789", "minal4335", "mohan987" };

                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Registration_Form (name, email, password, phone) VALUES (@Name, @Email, @Password, @Phone)", con);
                        cmd.Parameters.AddWithValue("@Name", names[i]);
                        cmd.Parameters.AddWithValue("@Email", emails[i]);
                        cmd.Parameters.AddWithValue("@Password", passwords[i]);
                        cmd.Parameters.AddWithValue("@Phone", phones[i]);

                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Record Inserted Successfully");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }


        //private string InputValidData(string message, string regex, string errorMessage)
        //{
        //    while (true)
        //    {
        //        Console.Write(message);
        //        string inputData = Console.ReadLine();

        //        Regex reg = new Regex(regex);

        //        if (reg.IsMatch(inputData))
        //        {
        //            return inputData;
        //        }

        //        Console.WriteLine(errorMessage);
        //    }
        //}
    }
}
