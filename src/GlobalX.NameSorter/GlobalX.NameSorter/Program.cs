using System;
using System.IO;
using System.Linq;

namespace GlobalX.NameSorter
{
    internal class Program
    {
        private static readonly string SaveFileName = "sorted-names-list.txt";

        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Please enter the file name of unsorted names");
                return;
            }
            
            string originalFilePath = args[0];

            // initialize the data store which will handle actual file I/O operations
            var dataStore = new FileBasedNameDataStore(originalFilePath);
             
            // build the decorators which will handle each concern seperately.
            var nameSortService = new NameSortService(); // for actual sorting
            var nameServiceConsoleDecorator = new NameServiceConsoleOutputDecorator(nameSortService); // for printing in console
            var nameServiceFileSaveDecorator = new NameServiceFileSaveDecorator(SaveFileName, nameServiceConsoleDecorator, dataStore); // for saving in disk

            // do the actual sorting
            var allSorted = nameServiceFileSaveDecorator.Sort(dataStore.Get()).ToList();
 
            Console.WriteLine("\n\nSaved file with sorted name in '{0}' with {1} records", SaveFileName, allSorted.Count);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
