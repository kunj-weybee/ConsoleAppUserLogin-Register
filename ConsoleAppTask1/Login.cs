using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTask1
{
    internal class Login
    {
        private string email;
        private string password;

        public Login(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        public void UserLogin()
        {
            if (ValidateUser(email, password) > 0)
            {
                Console.WriteLine("User login successfully");
            }

            else
            {
                Console.WriteLine("please enter valid username and password");
            }

            Console.ReadLine();
        }


        private int ValidateUser(string email, string password)
        {
            string conn = ConfigurationManager.ConnectionStrings["CreateConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                int count = 0;
                string query = $"SELECT COUNT(*) FROM Registration_Form WHERE email = '{email}' AND Password = '{password}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                    return count;
                }
            }
        }
    }
}

