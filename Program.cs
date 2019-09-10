using System;

namespace Camel
{
    class Program
    {
        static int narwhalExhaustion;
        static int distance;
        static int goal;
        static int drinks;
        static int userThirst;
        static int slimeDistance;
        static Boolean done;
        static String userInput;
        static Random rnd = new Random();

        //Distance
        static int halfSpeed;
        static int fullSpeed;

        private static void GameConditions()
        {
            narwhalExhaustion = 0;
            userThirst = 0;
            distance = 0;
            goal = 50;
            slimeDistance = -20;
            drinks = 3;
            done = false;
        }

        //User Options
        private static void Options()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("A.Drink");
            Console.WriteLine("B.Half Speed");
            Console.WriteLine("C.Fully Speed");
            Console.WriteLine("D.Maximum overdrive");
            Console.WriteLine("E.Rest");
            Console.WriteLine("F.Status");
            Console.WriteLine("Q.Quit");
            Console.Write("Your choice? ");
            CheckOptions();
        }

        private static void CheckOptions()
        {
            userInput = Console.ReadLine();
            if (userInput.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thanks for playing!");
                done = true;
            }
            else if (userInput.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                Drink();
            }
            else if (userInput.Equals("B", StringComparison.OrdinalIgnoreCase))
            {
                HalfSpeed();
            }
            else if (userInput.Equals("C", StringComparison.OrdinalIgnoreCase))
            {
                FullSpeed();
            }
            else if (userInput.Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                MaximumOverDrive();
            }
            else if (userInput.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                Rest();
            }
            else if (userInput.Equals("F", StringComparison.OrdinalIgnoreCase))
            {
                CheckStatus();
            }
            else
            {
                Console.WriteLine("Not an option");
            }
        }

        //Statuses
        private static void Status()
        {
            CheckGoal();
            CheckExhaustion();
            CheckNativesDistance();
            CheckThirst();
        }

        private static void CheckExhaustion()
        {
            if (narwhalExhaustion >= 8)
            {
                Console.Write("your narwhal died. Thanks for playing!");
                done = true;
            }
            else if (narwhalExhaustion >= 4 && distance < goal && slimeDistance < distance && userThirst < 5)
            {
                Console.WriteLine("Your narwhal is tired");
            }
        }

        private static void CheckNativesDistance()
        {
            if (slimeDistance >= distance)
            {
                Console.WriteLine("The natives have caught up to you and its over!");
                done = true;
            }
            else if (slimeDistance >= distance - 10 && distance < goal && narwhalExhaustion < 8 && userThirst < 5)
            {
                Console.WriteLine("The natives are getting close to you.");
            }
        }

        private static void CheckDrink()
        {
            if (drinks == 0)
            {
                Console.WriteLine("You have no drinks left.");
            }
            else if (userInput.Equals("F", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("You have " + drinks + " drinks left.");
            }
            else
            {
                Console.WriteLine("You drank from your bottle.");
            }
        }
        private static void CheckThirst()
        {
            if (userThirst >= 5)
            {
                Console.WriteLine("You died of thirst.");
            }
            else if (userThirst >= 3 && distance < goal && slimeDistance < distance && narwhalExhaustion < 8)
            {
                Console.WriteLine("You are feeling thirst.");
            }
        }

        private static void CheckGoal()
        {
            if (distance >= goal && narwhalExhaustion < 8 && slimeDistance < distance && userThirst < 5)
            {
                Console.WriteLine("You made it! Thank you for playing!");
                done = true;
            }
        }

        private static void SpaceDudeChance()
        {
            if (rnd.Next(20) == 5 && distance < goal && slimeDistance < distance 
                && userThirst < 5 && narwhalExhaustion < 10)
            {
                Console.WriteLine("You have found a special place! Your drinks will " +
                    "be refilled and your thingy will feel well rested");
                drinks = 3;
                userThirst = 0;
                narwhalExhaustion = 0;
            }
        }

        //Actions
        private static void Drink()
        {
            userThirst = 0;
            drinks -= 1;
            CheckDrink();
        }

        private static void HalfSpeed()
        {
            halfSpeed = rnd.Next(1, 5);
            narwhalExhaustion += 1;
            distance += halfSpeed;
            slimeDistance += rnd.Next(1, 7);
            Console.WriteLine("\nYou have traveled " + halfSpeed + " feet.");
            SpaceDudeChance();
            Status();
        }

        private static void FullSpeed()
        {
            fullSpeed = rnd.Next(5, 10);
            narwhalExhaustion += 3;
            distance += fullSpeed;
            slimeDistance += rnd.Next(2, 15);
            Console.WriteLine("You have traveled " + fullSpeed + " feet.");
            SpaceDudeChance();
            Status();
        }

        private static void MaximumOverDrive()
        {
            narwhalExhaustion += 10;
            distance += 1000;
            Console.WriteLine("You travled so far and so fast you died.");
            done = true;
        }

        private static void Rest()
        {
            narwhalExhaustion -= 2;
            slimeDistance += rnd.Next(1, 5);
            Console.WriteLine("You rest with your thingy on the nice cold ground.");
            Status();
        }

        private static void CheckStatus()
        {
            Console.WriteLine("Miles traveled: " + distance +
                "\nThe enemy is behind you by " + slimeDistance + " feet.");
            CheckDrink();
        }

        static void Main(string[] args)
        {
            GameConditions();
            Console.WriteLine("Welcome to the game of running!\nThe goal is to get you and " +
                "your space narwhal to the end before the slime catches up to you and eats you.\n" +
                "Make sure to keep track of your thirst and your narwhals energy.\nNow, have fun!");
            while (!done)
            {
                Options();
            }
        }
    }
}
