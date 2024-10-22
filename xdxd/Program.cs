using System;
using System.Collections.Generic;
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
            Task.Delay(2000);
            JsonDeserializer();
            Login();
        }

        static void Login()
        {        
            Console.WriteLine("1) Log in your account\n2) Don't have an account? Register now.\n3) About test system");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Insert your login:");
                    string login = Console.ReadLine();

                    string jsonPath = @"./Users.json";
                    string usersJson = File.ReadAllText(jsonPath);
                    List<Users> currentUsers = JsonConvert.DeserializeObject<List<Users>>(usersJson);

                    bool isExist;

                    Console.WriteLine("Insert your login:");
                        break;
                default:
                    Console.WriteLine("Please, select between following numbers.");
                    Login();
                    break;
            }
            
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
