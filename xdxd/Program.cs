using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace xdxd
{
    internal class Program
    {    
            
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! The test system is still in development");
            Task.Delay(3000);
            JsonDeserializer();
            Login();
            Console.ReadKey();
        }

        static void Login()
        {        
            Console.WriteLine("1) Log in your account\n2) Don't have an account? Sign up now.\n3) About test system");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Insert your login:");
                    string login = Console.ReadLine();

                    string jsonPath = @"./Users.json";
                    string usersJson = File.ReadAllText(jsonPath);
                    List<Users> currentUsers = JsonConvert.DeserializeObject<List<Users>>(usersJson);

                    bool isUserExist = currentUsers.Exists(user => user.UserName == login);

                    if (isUserExist)
                    {
                        Console.WriteLine("Insert your password:");
                        string password = Console.ReadLine();

                        Users userData = currentUsers.Find(user => user.UserName == login);
                        if (userData.Password == password)
                        {
                            Console.WriteLine($"Welcome {userData.UserName}!");
                        }
                        else
                        {
                            Console.WriteLine("Password is incorrect.");
                            Task.Delay(3000);
                            Login();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Login is incorrect (no users found).");
                        Task.Delay(3000);
                        Login();
                    }
                        break;
                case 2:

                    break;
                default:
                    Console.WriteLine("Please, select between following numbers.");
                    Login();
                    break;
            }
            
        }

        static void SignUp()
        {
            Console.WriteLine("Let's create your account!");
            Console.WriteLine("Enter you're login:");
            string login = Console.ReadLine();


            string jsonPath = @"./Users.json";
            string usersJson = File.ReadAllText(jsonPath);
            List<Users> currentUsers = JsonConvert.DeserializeObject<List<Users>>(usersJson);


        }
       
        static void JsonDeserializer()
        {
            try
            {
                string jsonPath = @"./Users.json";
                string usersJson = File.ReadAllText(jsonPath);
                List<Users> currentUsers = JsonConvert.DeserializeObject<List<Users>>(usersJson);

                //foreach (Users currentUser in currentUsers)
                //{
                //    Console.WriteLine($"User Id: {currentUser.UserId}, Username: {currentUser.UserName}");
                //}

            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                Console.WriteLine(exception);
            }
        }
    }
}
