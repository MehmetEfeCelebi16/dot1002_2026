using System;
using System.Collections.Generic;
using System.Threading;

namespace Brostpunk
{
    class Program
    {
        // Static variables for non-OOP structure
        static int heatStamps = 0;
        static int warnings = 0;
        static List<string> inventoryNames = new List<string>();
        static List<int> inventoryValues = new List<int>();
        static bool hasCaptainsWatch = false;
        static Random rnd = new Random();
        
        static bool[] locationsVisited = new bool[5];
        static int visitedCount = 0;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("               BROSTPUNK                ");
            Console.WriteLine("========================================");
            Console.WriteLine("Your sibling is severely ill. You rush them to the doctor.");
            Console.WriteLine("The doctor demands 25 Heat Stamps for the treatment, but you have nothing.");
            Console.WriteLine("The doctor allows your sibling to stay in a hospital bed for now.");
            Console.WriteLine("You must explore the freezing city to gather the required Heat Stamps.\n");
            Console.WriteLine("Press any key to begin your desperate journey...");
            Console.ReadKey(true);

            GameLoop();
        }

        static void GameLoop()
        {
            while (true)
            {
                if (warnings >= 3)
                {
                    Console.Clear();
                    Console.WriteLine("You have committed too many crimes and were thrown into prison!");
                    Console.WriteLine("Your sibling could not be saved. YOU LOST!");
                    return;
                }

                Console.Clear();
                Console.WriteLine("--- CITY STREETS ---");
                Console.WriteLine($"Heat Stamps: {heatStamps} | Guard Warnings: {warnings}/3");
                Console.WriteLine("\nWhat will you do? (Press 'I' to view inventory)");
                
                if (visitedCount < 5)
                {
                    Console.WriteLine("1- Explore a Location");
                }
                else
                {
                    Console.WriteLine("1- Explore a Location (All locations visited!)");
                }
                
                Console.WriteLine("2- Go to the Merchant");
                Console.WriteLine("3- Return to the Doctor");

                ConsoleKeyInfo key = Console.ReadKey(true);
                char input = char.ToLower(key.KeyChar);

                if (input == 'i')
                {
                    ShowInventory();
                }
                else if (input == '1' && visitedCount < 5)
                {
                    ChooseLocation();
                }
                else if (input == '2')
                {
                    VisitMerchant();
                }
                else if (input == '3')
                {
                    if (VisitDoctor()) return; // If VisitDoctor returns true, game ends
                }
            }
        }

        static void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("--- INVENTORY ---");
            Console.WriteLine($"Heat Stamps: {heatStamps}");
            if (inventoryNames.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                for (int i = 0; i < inventoryNames.Count; i++)
                {
                    Console.WriteLine($"- {inventoryNames[i]} (Value: {inventoryValues[i]} stamps)");
                }
            }
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey(true);
        }

        static int RollDice(int sides)
        {
            Console.WriteLine("\nPress 'e' to roll the dice...");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (char.ToLower(key.KeyChar) == 'e') break;
            }
            Console.WriteLine("Rolling...");
            Thread.Sleep(800);
            int result = rnd.Next(1, sides + 1);
            Console.WriteLine($"Result: {result}!");
            Thread.Sleep(500);
            return result;
        }

        static void AddItem(string name, int value)
        {
            inventoryNames.Add(name);
            inventoryValues.Add(value);
            Console.WriteLine($"[+] You obtained: {name} (Worth {value} stamps)");
        }

        static void GiveWarning()
        {
            warnings++;
            Console.WriteLine($"[!] The Guards caught you! Warning added. (Total: {warnings}/3)");
        }

        static void ChooseLocation()
        {
            Console.Clear();
            Console.WriteLine("Where will you go?");
            if (!locationsVisited[0]) Console.WriteLine("1- The Coal Mine");
            if (!locationsVisited[1]) Console.WriteLine("2- The Kitchen");
            if (!locationsVisited[2]) Console.WriteLine("3- The Generator Square");
            if (!locationsVisited[3]) Console.WriteLine("4- The Abandoned Tents");
            if (!locationsVisited[4]) Console.WriteLine("5- The Old Warehouse");
            Console.WriteLine("0- Go Back");

            char choice = Console.ReadKey(true).KeyChar;

            switch (choice)
            {
                case '1': if (!locationsVisited[0]) { VisitCoalMine(); locationsVisited[0] = true; visitedCount++; } break;
                case '2': if (!locationsVisited[1]) { VisitKitchen(); locationsVisited[1] = true; visitedCount++; } break;
                case '3': if (!locationsVisited[2]) { VisitGenerator(); locationsVisited[2] = true; visitedCount++; } break;
                case '4': if (!locationsVisited[3]) { VisitTents(); locationsVisited[3] = true; visitedCount++; } break;
                case '5': if (!locationsVisited[4]) { VisitWarehouse(); locationsVisited[4] = true; visitedCount++; } break;
                case '0': return;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }

        // --- LOCATION METHODS ---

        static void VisitCoalMine()
        {
            Console.Clear();
            Console.WriteLine("--- THE COAL MINE ---");
            Console.WriteLine("1- Sneakily steal some coal (Worth 10 stamps)");
            Console.WriteLine("2- Talk to the foreman and work for 1 day (Earn 5 stamps)");

            char choice = Console.ReadKey(true).KeyChar;
            if (choice == '1')
            {
                int roll = RollDice(20);
                if (roll >= 10)
                {
                    Console.WriteLine("You successfully stole the coal and slipped away!");
                    AddItem("Stolen Coal", 10);
                }
                else
                {
                    Console.WriteLine("You were spotted! You dropped the coal and fled.");
                    GiveWarning();
                }
            }
            else
            {
                Console.WriteLine("You worked hard all day and earned 5 Heat Stamps.");
                heatStamps += 5;
            }
        }

        static void VisitKitchen()
        {
            Console.Clear();
            Console.WriteLine("--- THE KITCHEN ---");
            Console.WriteLine("You offer to wash the dishes. It's grueling work in the freezing water.");
            Console.WriteLine("You earn 5 Heat Stamps for your labor.");
            heatStamps += 5;
        }

        static void VisitGenerator()
        {
            Console.Clear();
            Console.WriteLine("--- THE GENERATOR SQUARE ---");
            Console.WriteLine("1- Steal a well-dressed woman's necklace (Worth 15 stamps)");
            Console.WriteLine("2- Steal the Mayor's watch (Worth 20 stamps)");
            Console.WriteLine("3- Pickpocket a random man's wallet (Worth 5 stamps)");

            char choice = Console.ReadKey(true).KeyChar;
            if (choice == '1')
            {
                Console.WriteLine("Attempting to steal from the woman...");
                if (RollDice(20) > 5)
                {
                    Console.WriteLine("You slipped the necklace! Now checking for guards...");
                    if (RollDice(20) >= 10)
                    {
                        Console.WriteLine("You got away safely!");
                        AddItem("Woman's Necklace", 15);
                    }
                    else GiveWarning();
                }
                else Console.WriteLine("She noticed you! You had to run away empty-handed.");
            }
            else if (choice == '2')
            {
                Console.WriteLine("Attempting to steal the Mayor's watch... High risk!");
                if (RollDice(20) > 15)
                {
                    Console.WriteLine("You grabbed the watch! Now checking for guards...");
                    if (RollDice(20) >= 18)
                    {
                        Console.WriteLine("A master thief! You got away.");
                        AddItem("Mayor's Watch", 20);
                    }
                    else GiveWarning();
                }
                else Console.WriteLine("The Mayor caught your hand! You barely escaped.");
            }
            else if (choice == '3')
            {
                Console.WriteLine("You grabbed the wallet. Checking for guards...");
                if (RollDice(20) >= 10)
                {
                    Console.WriteLine("Success! You vanished into the crowd.");
                    AddItem("Random Wallet", 5);
                }
                else GiveWarning();
            }
        }

        static void VisitTents()
        {
            Console.Clear();
            Console.WriteLine("--- THE ABANDONED TENTS ---");
            Console.WriteLine("You enter an empty tent and find two chests.");
            Console.WriteLine("1- Rummage through the Normal Chest");
            Console.WriteLine("2- Try to open the Digital Locked Chest");

            char choice = Console.ReadKey(true).KeyChar;
            if (choice == '1')
            {
                int roll = rnd.Next(1, 5);
                if (roll == 1) AddItem("Robot Toy", 5);
                else if (roll == 2) AddItem("Ring", 10);
                else if (roll == 3) AddItem("Fur", 5);
                else AddItem("Camera", 10);
            }
            else
            {
                Console.WriteLine("MINIGAME: Move the square from start to finish in exactly 3 moves.");
                Console.WriteLine("Path: Right, Up, Right.");
                Console.WriteLine("Use 'w' (Up) and 'd' (Right) keys.");
                
                string moves = "";
                for(int i=0; i<3; i++)
                {
                    moves += char.ToLower(Console.ReadKey(true).KeyChar);
                    Console.Write("* ");
                }
                Console.WriteLine();

                if (moves == "dwd")
                {
                    Console.WriteLine("Password cracked successfully! Here is your reward:");
                    int roll = RollDice(20);
                    if (roll >= 18)
                    {
                        Console.WriteLine("You found a note: 'The City Must Survive!'");
                        AddItem("Captain's Pocket Watch", 50);
                        hasCaptainsWatch = true;
                    }
                    else if (roll >= 10) AddItem("High Quality Fur", 20);
                    else AddItem("Quality Boots", 10);
                }
                else
                {
                    Console.WriteLine("Incorrect sequence! The chest locked down permanently.");
                }
            }
        }

        static void VisitWarehouse()
        {
            Console.Clear();
            Console.WriteLine("--- THE OLD WAREHOUSE ---");
            Console.WriteLine("You found a Food Basket (Worth 5 stamps) and 5 Heat Stamps lying around.");
            heatStamps += 5;
            Console.WriteLine("Suddenly, you hear guards approaching!");
            
            int roll = RollDice(20);
            if (roll >= 15)
            {
                Console.WriteLine("You found 5 more Heat Stamps on the ground while escaping unseen!");
                heatStamps += 5;
                AddItem("Food Basket", 5);
            }
            else if (roll >= 10)
            {
                Console.WriteLine("You escaped without being caught!");
                AddItem("Food Basket", 5);
            }
            else
            {
                Console.WriteLine("The guards spotted you! You had to drop the basket to run faster.");
                GiveWarning();
            }
        }

        static void VisitMerchant()
        {
            Console.Clear();
            Console.WriteLine("--- THE MERCHANT ---");
            if (inventoryNames.Count == 0)
            {
                Console.WriteLine("You have nothing to sell.");
            }
            else
            {
                Console.WriteLine("You sold all your items to the merchant.");
                for (int i = 0; i < inventoryNames.Count; i++)
                {
                    Console.WriteLine($"- Sold {inventoryNames[i]} for {inventoryValues[i]} stamps.");
                    heatStamps += inventoryValues[i];
                }
                inventoryNames.Clear();
                inventoryValues.Clear();
                Console.WriteLine($"\nYou now have {heatStamps} Heat Stamps in total.");
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadKey(true);
        }

        static bool VisitDoctor()
        {
            Console.Clear();
            Console.WriteLine("--- THE HOSPITAL ---");
            
            // Check Final Fate Roll first
            if (!hasCaptainsWatch)
            {
                Console.WriteLine("Before you reach the doctor, a terrible chill fills the air...");
                Console.WriteLine("FINAL FATE ROLL!");
                int roll = RollDice(20);
                if (roll == 1)
                {
                    Console.WriteLine("A MASSIVE STORM HIT!!!");
                    Console.WriteLine("The hospital froze over completely. Your sibling could not be saved.");
                    Console.WriteLine("YOU LOST!");
                    return true; 
                }
                else
                {
                    Console.WriteLine("The weather holds up. You reach the doctor's office.");
                }
            }
            else
            {
                Console.WriteLine("The Captain's Watch glows faintly... The harsh weather bypasses the hospital.");
            }

            Console.WriteLine("\nYou approach the Doctor...");
            if (heatStamps >= 25)
            {
                Console.WriteLine("You hand over the 25 Heat Stamps. The doctor applies the medicine.");
                Console.WriteLine("Your sibling is saved! CONGRATULATIONS, YOU WON!");
                return true;
            }
            else if (heatStamps >= 15)
            {
                Console.WriteLine($"'Doctor, unfortunately I couldn't gather 25 stamps, but I have {heatStamps}.'");
                Console.WriteLine("'Please, save my sibling's life just this once!'");
                
                if (RollDice(20) >= 5)
                {
                    Console.WriteLine("\nDoctor: 'Alright... Your sibling's condition is severe. I will accept this for now.'");
                    Console.WriteLine("Your sibling is saved! CONGRATULATIONS, YOU WON!");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nDoctor: 'I am sorry, but medicine is scarce. I cannot make exceptions.'");
                    Console.WriteLine("You couldn't gather enough Heat Stamps. YOU LOST!");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("'Doctor, unfortunately I couldn't gather enough stamps...'");
                Console.WriteLine("\nDoctor: 'I am so sorry for you and your sibling. You must say your goodbyes.'");
                Console.WriteLine("Doctor: 'I will leave you two alone...'");
                Console.WriteLine("\n'I'm so sorry... I couldn't get the stamps to save you...'");
                Console.WriteLine("Sibling: 'It's okay... I should have taken better care of my health. If our generator doesn't die, maybe we'll meet again. Goodbye...'");
                Console.WriteLine("\nYou couldn't gather enough Heat Stamps. YOU LOST!");
                return true;
            }
        }
    }
}