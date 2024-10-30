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
        // variables naming are awful, rename later!!!
        static string currentUser; 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! The test system is still in development");
            Task.Delay(3000);
            
           // JsonDeserializer();
            Login();
            Console.ReadKey();
        }

        static void Login()
        {
            
            Console.WriteLine("1) Log in your account\n2) Don't have an account? Sign up now.\n3) About test system");    
            try
            {
                int choice = int.Parse(Console.ReadLine()); //exception if user enters non-int variable, fix this u dumbass | done, very poorly, unlucky
                switch (choice)
                {
                    case 1: //re-do log in with methods (optimization) -- in process
                        Console.WriteLine("Insert your login:");
                        string login = Console.ReadLine();

                        //string jsonPath = @"./Users.json";
                        //string usersJson = File.ReadAllText(jsonPath);
                        List<Users> User = GetUserFromFile();

                        //bool isUserExist = currentUsers.Exists(user => user.UserName == login);

                        if (IsUserExist(login)) //to much shit is going on here, re-do later
                        {
                            Console.WriteLine("Insert your password:");
                            string password = Console.ReadLine();

                            Users userData = GetUserByUsername(login); //null reference, debug this u dumbass (done)
                            if (userData.Password == password)
                            {
                                currentUser = userData.UserName;
                                Authorization();
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
                        SignUp();
                        break;
                    default:
                        Console.WriteLine("Please, select between following numbers.");
                        Login();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please, select between following numbers.");
                Login();
                throw; // sometimes catching wierd shit, idk, will researh it later 
            }                      
        }

        static void Authorization()
        {
            Console.Clear();
            Console.WriteLine($"Hello {currentUser}!");
        }

        static void SignUp()
        {
            Console.Clear();
            Console.WriteLine("Let's create your account!\nEnter your login:");
            string login = Console.ReadLine();


            ////
                //string jsonPath = @"./Users.json"; //same shit, re-do later
                //string usersJson = File.ReadAllText(jsonPath);
                //List<Users> currentUsers = JsonConvert.DeserializeObject<List<Users>>(usersJson);
            ///// - old 

            //// - new
            List<Users> users = GetUserFromFile();

            if (IsUserExist(login))
            {
                Console.WriteLine("Current username is taken, please choose a differnt one");
                Task.Delay(7000);
                Login();
            }
           
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            Users newUser = new Users()
            {
                UserId = GetNextUserId(),
                UserName = login,
                Password = password
            };
               
            List<Users> currentUsers = GetUserFromFile();
            currentUsers.Add(newUser);
            AddUsersToFile(currentUsers);
            Console.WriteLine($"User {newUser.UserName} added successfully, please log in;");
            Login();

        }
       
        static void JsonDeserializer() //will delete in the future -- almost done with replacing the whole method, just ignore it
        {
            try
            {
                string jsonPath = @"./Users.json"; //same shit, re-do later
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

        static void AddUsersToFile(List<Users> users)
        {
            string path = @"./Users.json";
            string UsersJson = JsonConvert.SerializeObject(users, Formatting.Indented); //wtf is that naming . . . it's confusing even for myself, others will rope themselves after rewiewing my code
            File.WriteAllText(path, UsersJson);
        }

        static int GetNextUserId()
        {
            List<Users> users = GetUserFromFile();
            return users.Count > 0 ? users[users.Count - 1].UserId + 1 : 1;
        }

        static List<Users> GetUserFromFile()
        {
            string jsonPath = @"./Users.json"; 
            string usersJson = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<List<Users>>(usersJson);
        }

        static bool IsUserExist(string username)
        {
            List<Users> users = GetUserFromFile();
            return users.Exists(user => user.UserName == username);
        }

        static Users GetUserByUsername(string username)
        {
            List<Users> users = GetUserFromFile();
            return users.Find(user => user.UserName == username);
        }
    }
}
