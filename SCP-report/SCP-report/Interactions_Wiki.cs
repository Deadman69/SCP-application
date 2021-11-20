using System;
using System.Collections.Generic;
using System.Text;

namespace SCP_report
{
    class Interactions_Wiki
    {
        public User currentUser;
        public Interactions parentElement;

        public Interactions_Wiki(User currentUser, Interactions parentElement)
        {
            this.currentUser = currentUser;
            this.parentElement = parentElement;
        }

        public void wiki_Users() {
            Console.Clear();
            Console.WriteLine("------ WIKI - USERS ------");
            Console.WriteLine("");
        }

        public void wiki_Classification() {
            Console.Clear();
            Console.WriteLine("------ WIKI - CLASSIFICATION ------");
            Console.Write("\n1. Personnal classification");
            Console.Write("\n2. SCP classification");
            Console.Write("\n\n0. Go back\n-->");
            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    this.wiki_Classification_Users();
                    break;
                case 2:
                    //this.wiki_Classification_SCP();
                    break;
                default:
                    this.parentElement.chooseAction();
                    break;
            }
        }

        public void wiki_Classification_Users() {
            Console.Clear();
            Console.WriteLine("------ WIKI - PERSONNAL CLASSIFICATION ------");
            Console.Write("\nFive clearance levels (accreditation) exist for foundation personnal :");
            Console.Write("\n   1 : Confidential\n      Used for base employees foundation such as janitors or administrative personnal.");
            Console.Write("\n   2 : Restreined\n      Used for researchers and security officers that need direct informations about SCP's.");
            Console.Write("\n   3 : Secret\n      Used for teams supervisors, Mobile Task Force officers. Give access to many SCP's details intels.");
            Console.Write("\n   4 : Top-secret\n      Used for site directors and Mobile Task Force Commander, give access to almost every SCP's intels.");
            Console.Write("\n   5 : Thaumiel\n      Used for O-5 Council members. Give access to all the SCP's intels.");

            Console.Write("\n\nFive classification (accreditation) exist for foundation personnal :");
            Console.Write("\n   E :\n      Temporary, used for personnal who have been exposed to a dangerous SCP recently. They must be placed under surveillance.");
            Console.Write("\n   D :\n      Replacable personnal. Widely used for inmates used for dangerous experiences with SCP's.");
            Console.Write("\n   C :\n      Used for base employees foundation who need access to SCP's considered as not dangerous.");
            Console.Write("\n   B :\n      Essential personnal for the foundation in a local scale.");
            Console.Write("\n   A :\n      Vital personnal for the foundation in a worldwide scale. O-5 Council members are automatically on this classification.");

            Console.Write("\n\nPress any key to exit");
            Console.ReadKey();
            this.parentElement.displayWiki();
        }
    }
}
