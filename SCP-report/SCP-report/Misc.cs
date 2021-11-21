using System;
using System.Collections.Generic;
using System.Text;

namespace SCP_report
{
    class Misc
    {
        public static void init() {
            // If the Users file doest not exist or if no user exist
            if(!System.IO.File.Exists(Config.STORAGE_FILE_USER) || SCPFileHandler.getUsers().ToArray().Length == 0) {
                User admin = new User("admin", "admin", 5, "admin", "admin");
                System.IO.File.Create(Config.STORAGE_FILE_USER);

                Console.WriteLine("----- WELCOME -----");
                Console.WriteLine("This is your first time here, you need to create an admin user wich have the highest permissions.");
                /*Console.Write("\nChoose the admin login : ");
                admin.login = Console.ReadLine();
                Console.Write("Choose the admin password : ");
                admin.password = Console.ReadLine();*/

                if(SCPFileHandler.saveUsers(new List<User>() { admin })) {
                    Misc.displayColoredMessage("User created successfully. Redirecting...", ConsoleColor.Green);
                    System.Threading.Thread.Sleep(1500);
                    return;
                } else {
                    Misc.displayColoredMessage("An error occured while saving the user, try again. Redirecting...", ConsoleColor.Red);
                    System.Threading.Thread.Sleep(1500);
                    Misc.init();
                    return;
                }
            }
            
            // If the SCP file doest not exist
            if(!System.IO.File.Exists(Config.STORAGE_FILE_SCP))
                System.IO.File.Create(Config.STORAGE_FILE_SCP);
        }

        public static void displayColoredMessage(string message, ConsoleColor color) {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = previousColor;
        }

        /**
         * @param string typeExpected : "int", "string"
         * @param string errorMessage : message showed if user input a wrong value
         * @param string breakLoopValueInput : if user input this string, we will get out of loop returning fallbackValue
         */
        public static string retryEntryUntilGood(string fieldDisplay, string typeExpected, string breakLoopValueInput, string errorMessage, string fallbackValue) {
            bool shouldContinue = true;
            string toReturn = fallbackValue;
            while(shouldContinue) {
                Console.Write(fieldDisplay);
                string valueInput = Console.ReadLine();
                if(valueInput == breakLoopValueInput && breakLoopValueInput != "") {
                    return toReturn;
                }
                bool typeOK = false;
                if(typeExpected == "int") {
                    if (int.TryParse(valueInput, out _)) {
                        typeOK = true;
                    }
                } else {
                    typeOK = true;
                }

                if(typeOK) {
                    shouldContinue = false;
                    toReturn = valueInput;
                } else {
                    Misc.displayColoredMessage(errorMessage, ConsoleColor.Red);
                }
            }
            return toReturn;
        }
    }
}
