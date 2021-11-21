using System;
using System.Collections.Generic;
using System.Text;

namespace SCP_report
{
    class Interactions_SCP
    {
        public User currentUser;
        public Interactions parentElement;

        public Interactions_SCP(User currentUser, Interactions parentElement)
        {
            this.currentUser = currentUser;
            this.parentElement = parentElement;
        }

        public void scp_NewScp() {
            Console.Clear();
            Console.WriteLine("------ SCP CREATION ------");
            bool shouldContinueDesignation = true;
            SCP scpToRegister = new SCP();
            while (shouldContinueDesignation)
            {
                Console.Write("Designation : ");
                string designation = Console.ReadLine();
                SCP scpToCheck = new SCP(designation);
                if (scpToCheck.exist()) {
                    Misc.displayColoredMessage("This SCP already exist ! Try another designation !", ConsoleColor.Red);
                } else {
                    scpToRegister.designation = designation;
                    shouldContinueDesignation = false;
                }
            }
            Console.Write("Alternative name : ");
            string alterName = Console.ReadLine();
            scpToRegister.alterName = alterName;
            Console.Write("Classification : ");
            string classification = Console.ReadLine();
            scpToRegister.classification = classification;
            Console.Write("Site where the SCP is contained : ");
            string site = Console.ReadLine();
            scpToRegister.site = site;
            Console.Write("Note (leave empty if any) : ");
            string note = Console.ReadLine();
            scpToRegister.note = note;

            if (SCPFileHandler.saveSCPs(new List<SCP>() { scpToRegister }))
            {
                Misc.displayColoredMessage("\nSCP created successfully. Redirecting...", ConsoleColor.Green);
                System.Threading.Thread.Sleep(1500);
                parentElement.displaySCPManagement();
                return;
            }
        }

        public void scp_List() {
            Console.Clear();
            Console.WriteLine("------ SCP LIST ------");
            List<SCP> scps = SCPFileHandler.getSCPs();
            foreach (SCP scp in scps)
            {
                //if (!scp.isHidden)
                    Console.WriteLine(scp.ToString());
            }
            Console.WriteLine("\n\nPress any key to exit.");
            // Wait for input to close
            Console.ReadKey();
            this.parentElement.displaySCPManagement();
            return;
        }
    }
}
