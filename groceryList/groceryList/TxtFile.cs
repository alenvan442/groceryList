using System;
using System.IO;
using System.Collections.Generic;

namespace GroceryList
{
    public class TxtFile
    {

        public static Dictionary<string, int> MakeList()
        {
            /*
             * a method that creates a grocery list and asks if the user wants to add more or not
             * RETURN: dictionary of items and the amount of the item
             */
            Console.WriteLine("Now let's create your grocery list...");
            Dictionary<string, int> groceryList = new Dictionary<string, int>();


            //loop until the user does not want to add any more items
            while (true)
            {
                //asks the user for an item
                Console.Write("\nPlease enter an item you would like to buy: ");
                string item = Console.ReadLine();

                //checks to see if the input is valid
                if (string.IsNullOrEmpty(item))
                {
                    int i = 0;
                    while (i == 0)
                    {
                        //if input was empty as if they would like to stop
                        //if Y then return the dictioanry
                        //if N then continue
                        //if input was invalid reprompt if they want to stop
                        Console.Write("You did not input anything, would you like to stop adding items? [Y/N]: ");
                        string _continue = Console.ReadLine().Trim().ToLower();

                        if (string.IsNullOrEmpty(_continue))
                        {
                            Console.WriteLine("Please enter a valid response.\n");
                        }
                        else
                        {
                            _continue = _continue.Substring(0, 1);
                            switch (_continue)
                            {
                                case "y":
                                    return groceryList;
                                case "n":
                                    i = 1;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid response.\n");
                                    continue;
                            }
                        }

                    }


                }
                else
                {

                    //since the input was valid we ask how many of that irem would the user like
                    while (true)
                    {
                        Console.Write("How many of this item are you planning on buying? ");
                        string amount = Console.ReadLine().Trim();

                        //check to see if the input is a valid int
                        //if input < 0, re prompt with a new request for an item
                        //if input not an int, repompt for an amount
                        //if input was valid add to the dictionary the item as the key and the value as the amount
                        if (!Int32.TryParse(amount, out int itemAmount))
                        {
                            Console.WriteLine("Please enter a valid integer.\n");
                            continue;
                        }
                        else
                        {
                            if (itemAmount < 0)
                            {
                                Console.WriteLine("Since the inputted value is less than 0, I presume you made a mistake and did not actually want to buy this item.\n");

                            }
                            else
                            {
                                groceryList.Add(item, itemAmount);

                            }
                        }

                        break;

                    }

                }

                int j = 0;
                while (j == 0)
                {
                    //after adding an item to the dictionary, ask if the player wants to add another item
                    //if yes reask for another item
                    //if no return list
                    //if input not y/n or empty, ask
                    Console.Write("Would you like to add another item? [Y/N]: ");
                    string _continue = Console.ReadLine().Trim().ToLower();

                    if (string.IsNullOrEmpty(_continue))
                    {
                        Console.WriteLine("Please enter a valid response.\n");
                    }
                    else
                    {
                        _continue = _continue.Substring(0, 1);
                        switch (_continue)
                        {
                            case "y":
                                j = 1;
                                break;
                            case "n":
                                return groceryList;
                            default:
                                Console.WriteLine("Please enter a valid response.\n");
                                continue;
                        }
                    }

                }

            }
        }

        public static List<string> dictionarySort(Dictionary<string, int> groceryList)
        {
            /*
             * method that uses the insertion sort algorithm to sort the dictionary's keys
             * then creates a list that consists of the item: amount by using the dictionary
             * 
             * groceryList: a dictionary with the item and amount
             * 
             * RETURN: list of strings with the item and amount
             */
            List<string> items = new List<string>();
            foreach (string i in groceryList.Keys)
            {
                items.Add(i);
            }

            //insertion sort
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (items[j].CompareTo(items[j - 1]) == -1)
                    {
                        var placeholder = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = placeholder;

                    }

                }
            }

            //adds the amount to each list item
            for (int i = 0; i < items.Count; i++)
            {
                items[i] = $"{items[i]}: {groceryList[items[i]]}";
            }

            return items;

        }

        public static void fileWrite(List<string> groceryList)
        {
            /*
             * creates and writes onto the grocery list
             * 
             * groceryList: a list of strings to write in the txt file
             */
            Console.WriteLine("\nCreating file: GroceryList.txt...");
            File.WriteAllLines("GroceryList.txt", groceryList);
            Console.WriteLine("\nSuccessfully created file: GroceryList.txt, in the debug file of this program.");
            Console.ReadLine();
        }


    }
}
