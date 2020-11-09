using System;
using System.Collections.Generic;
using System.IO;


namespace GroceryList
{
    class Program
    {
        public static void Main(string[] args)
        {

            Setup.Introduction();
            Dictionary<string, int> groceryList = TxtFile.MakeList();
            List<string> groceries = TxtFile.dictionarySort(groceryList);
            TxtFile.fileWrite(groceries);


        }
    }
}
