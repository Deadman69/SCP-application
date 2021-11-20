using System;
using System.Collections.Generic;
using System.Text;

namespace SCP_report
{
    class Interactions_User
    {
        public User currentUser;
        public Interactions parentElement;

        public Interactions_User(User currentUser, Interactions parentElement) {
            this.currentUser = currentUser;
            this.parentElement = parentElement;
        }

        public void user_NewUser()
        {
            Console.Clear();
            Console.WriteLine("------ USER CREATION ------");
            Console.WriteLine("(To cancel type your login)");
            bool shouldContinueLogin = true;
            User userToRegister = new User();
            while (shouldContinueLogin)
            {
                Console.Write("Login : ");
                string login = Console.ReadLine();
                if (login != this.currentUser.login)
                {
                    User userToCheck = new User(login);
                    if (userToCheck.exist())
                    {
                        Misc.displayColoredMessage("This user already exist ! Try another one !", ConsoleColor.Red);
                    }
                    else
                    {
                        userToRegister.login = login;
                        shouldContinueLogin = false;
                    }
                }
                else
                {
                    Misc.displayColoredMessage("Aborted. Redirecting...", ConsoleColor.Red);
                    System.Threading.Thread.Sleep(1500);
                    parentElement.displayUserManagement();
                    return;
                }
            }
            Console.Write("Password : ");
            string password = Console.ReadLine();
            userToRegister.password = password;
            Console.Write("Accreditation : ");
            int accreditation = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(accreditation + " - " + this.currentUser.ToString());
            if (accreditation > this.currentUser.accreditation)
            {
                Misc.displayColoredMessage("\nYou can't create a user with greater accreditation than you. Aborted.", ConsoleColor.Red);
                System.Threading.Thread.Sleep(1500);
                this.user_NewUser();
                return;
            }
            else if (accreditation > 5)
            {
                Misc.displayColoredMessage("\nYou can't create a user with greater accreditation than O-5 Council. Aborted.", ConsoleColor.Red);
                System.Threading.Thread.Sleep(1500);
                this.user_NewUser();
                return;
            }
            userToRegister.accreditation = accreditation;
            Console.Write("Classification : ");
            string classification = Console.ReadLine();
            userToRegister.classification = classification;
            Console.Write("Title: ");
            string title = Console.ReadLine();
            userToRegister.title = title;

            if (SCPFileHandler.saveUsers(new List<User>() { userToRegister }))
            {
                Misc.displayColoredMessage("\nUser created successfully. Redirecting...", ConsoleColor.Green);
                System.Threading.Thread.Sleep(1500);
                parentElement.displayUserManagement();
                return;
            }
        }

        public void user_Edit() {
            Console.Clear();
            Console.WriteLine("------ USER EDIT ------");
            Console.Write("Login to edit : ");
            string loginToEdit = Console.ReadLine();

        }

        public void user_Find()
        {
            Console.Clear();
            Console.WriteLine("------ USER FIND ------");
            Console.WriteLine("(To cancel type '0')");
            Console.Write("Login to search : ");
            string loginToFind = Console.ReadLine();
            User userToFind = new User(loginToFind);
            if (userToFind.exist())
            {
                userToFind = userToFind.getWithLogin();
                Console.WriteLine(userToFind.ToString());
                Console.WriteLine("\nPress any key to leave.");
                Console.ReadKey();
                parentElement.displayUserManagement();
                return;
            }
            else
            {
                Misc.displayColoredMessage("\nUser not finded. Try again...", ConsoleColor.Red);
                System.Threading.Thread.Sleep(1500);
                this.user_Find();
                return;
            }
        }

        public void user_Delete()
        {
            Console.Clear();
            Console.WriteLine("------ USER DELETION ------");
            Console.Write("Login : ");
            string loginToDelete = Console.ReadLine();
            User userToDelete = new User(loginToDelete);
            if (!userToDelete.exist())
            {
                Misc.displayColoredMessage("\nThis user does not exist. Aborted.", ConsoleColor.Red);
                System.Threading.Thread.Sleep(1500);
                parentElement.displayUserManagement();
                return;
            }
            else if (userToDelete.login == this.currentUser.login)
            {
                Misc.displayColoredMessage("\nYou can't delete yourself. Aborted.", ConsoleColor.Red);
                System.Threading.Thread.Sleep(1500);
                parentElement.displayUserManagement();
                return;
            }
            else
            {
                userToDelete.delete();
                Misc.displayColoredMessage("\nUser deleted successfully. Redirecting...", ConsoleColor.Green);
                System.Threading.Thread.Sleep(1500);
                parentElement.displayUserManagement();
                return;
            }
        }

        public void user_List()
        {
            Console.Clear();
            Console.WriteLine("------ USER LIST ------");
            List<User> users = SCPFileHandler.getUsers();
            foreach (User user in users)
            {
                if (!user.isHidden)
                    Console.WriteLine(user.ToString());
            }
            Console.WriteLine("\n\nPress any key to exit.");
            // Wait for input to close
            Console.ReadKey();
            parentElement.displayUserManagement();
            return;
        }
    }
}
