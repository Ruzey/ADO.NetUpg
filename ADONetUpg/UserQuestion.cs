using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetUpg
{
    internal class UserQuestion
    {
        public DbLogic dbLogic;
        bool isRunning = true;
        public UserQuestion()
        {
            dbLogic = new DbLogic();
        }
        public void WhichActor()
        {
            string firstName;
            string lastName;

            Console.Write("Ange förnamn: ");
            firstName = Console.ReadLine();
            Console.Write("Ange efternamn: ");
            lastName = Console.ReadLine();

            dbLogic.ActorNameStart(firstName, lastName);
        }

        void SmallMenu()
        {
            Console.WriteLine("\n1. Sök en skådespelare via förnamn+efternamn\n" +
                                "2. Avsluta");
        }

        public void RunProgram()
        {
            do
            {
                SmallMenu();
                SmallMenuChoices(UserInput());
            } while (isRunning);
        }

        public void SmallMenuChoices(string inputUser)
        {
            switch (inputUser)
            {
                case "1":
                    WhichActor();
                    break;
                case "2":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }
        }

        public string UserInput()
        {
            Console.Write("\nAnge ditt val: ");
            return Console.ReadLine();
        }
    }
}
