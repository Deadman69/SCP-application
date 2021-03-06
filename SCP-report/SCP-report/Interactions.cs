using System;
using System.Collections.Generic;
using System.Text;

namespace SCP_report
{
    public class Interactions
    {
        private User currentUser;

        public Interactions() {}

        public User login() {
            Console.Clear();
            Console.WriteLine("----- WELCOME TO THE SCP FOUNDATION -----");
            int tryRemaining = Config.LOGIN_TRY_MAX;
            bool shouldContinue = true;
            while (shouldContinue) {
                Console.Write((tryRemaining != Config.LOGIN_TRY_MAX ? "\n" : "") + "Login : ");
                string login = Console.ReadLine();
                Console.Write("Password : ");
                string password = Console.ReadLine();

                User tryUser = new User(login, password);
                if(tryUser.isLoginValid()) {
                    shouldContinue = false;
                    this.currentUser = tryUser.getWithLogin(); // Return complete user
                } else {
                    tryRemaining--;
                    if(tryRemaining > 0) {
                        string message = "Error, login or password incorrect. You have only " + tryRemaining + " tries left.";
                        Misc.displayColoredMessage(message, ConsoleColor.Red);
                    } else {
                        string message = "\n\nError, stay where you are. Mobile Task Force Units have been informed and will arrive to your position soon.\n\n";
                        Misc.displayColoredMessage(message, ConsoleColor.Red);
                        Environment.Exit(0);
                    }

                }
            }

            return this.currentUser;
        }

        public void chooseAction() {
            Console.Clear();
            Console.Write("----- CHOOSE AN ACTION -----");

            Console.Write("\n1. User management");
            Console.Write("\n2. SCP management");
            Console.Write("\n3. Wiki");
            Console.Write("\n\n\n0. Disconnect\n-->");
            int action = Convert.ToInt32(Misc.retryEntryUntilGood("", "int", "", "Error. Value not allowed, try again.", "0"));
            switch (action) {
                case 1:
                    this.displayUserManagement();
                    break;
                case 2:
                    this.displaySCPManagement();
                    break;
                case 3:
                    this.displayWiki();
                    break;
                default:
                    Console.Clear();
                    Console.Write("Goodbye.");
                    Environment.Exit(0);
                    break;
            }
        }

        public void displayUserManagement() {
            Console.Clear();
            Console.Write("----- USER MANAGEMENT -----");
            Console.Write("\n1. User creation");
            Console.Write("\n2. User modification (Not implemented yet)");
            Console.Write("\n3. User find");
            Console.Write("\n4. User deletion");
            Console.Write("\n5. User list");
            Console.Write("\n\n\n0. Go back\n-->");
            int action = Convert.ToInt32(Misc.retryEntryUntilGood("", "int", "", "Error. Value not allowed, try again.", "0"));

            Interactions_User iu = new Interactions_User(this.currentUser, this);
            switch (action) {
                case 1:
                    iu.user_NewUser();
                    break;
                case 2:
                    iu.user_Edit();
                    break;
                case 3:
                    iu.user_Find();
                    break;
                case 4:
                    iu.user_Delete();
                    break;
                case 5:
                    iu.user_List();
                    break;
                default:
                    this.chooseAction();
                    break;
            }
        }

        public void displaySCPManagement() {
            Console.Clear();
            Console.Write("----- SCP MANAGEMENT -----");
            Console.Write("\n1. SCP creation");
            Console.Write("\n2. SCP modification (Not implemented yet)");
            Console.Write("\n3. SCP find (Not implemented yet)");
            Console.Write("\n4. SCP deletion (Not implemented yet)");
            Console.Write("\n5. SCP list");
            Console.Write("\n\n\n0. Go back\n-->");
            int action = Convert.ToInt32(Misc.retryEntryUntilGood("", "int", "", "Error. Value not allowed, try again.", "0"));

            Interactions_SCP iscp = new Interactions_SCP(this.currentUser, this);
            switch (action) {
                case 1:
                    iscp.scp_NewScp();
                    break;
                case 2:
                    //iscp.scp_Edit();
                    break;
                case 3:
                    //iscp.scp_Find();
                    break;
                case 4:
                    //iscp.scp_Delete();
                    break;
                case 5:
                    iscp.scp_List();
                    break;
                default:
                    this.chooseAction();
                    break;
            }
        }

        public void displayWiki() {
            Console.Clear();
            Console.Write("----- WIKI -----");
            Console.Write("\n1. Users (Not implemented yet)");
            Console.Write("\n2. SCP (Not implemented yet)");
            Console.Write("\n3. Classification");
            Console.Write("\n\n\n0. Go back\n-->");
            int action = Convert.ToInt32(Misc.retryEntryUntilGood("", "int", "", "Error. Value not allowed, try again.", "0"));

            Interactions_Wiki ik = new Interactions_Wiki(this.currentUser, this);
            switch (action) {
                case 1:
                    //ik.wiki_Users();
                    break;
                case 2:
                    //ik.user_Edit();
                    break;
                case 3:
                    ik.wiki_Classification();
                    break;
                default:
                    this.chooseAction();
                    break;
            }
        }
    }
}
