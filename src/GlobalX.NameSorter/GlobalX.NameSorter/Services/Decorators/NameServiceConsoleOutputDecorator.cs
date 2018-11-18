using System.Collections.Generic;
using System.Linq;
using GlobalX.NameSorter.Abstractions;

namespace GlobalX.NameSorter
{
    public class NameServiceConsoleOutputDecorator : INameSortService
    {
        private readonly INameSortService _wrappedService;

        public NameServiceConsoleOutputDecorator(INameSortService wrappedService)
        {
            _wrappedService = wrappedService;
        }

        public IEnumerable<NameModel> Sort(IEnumerable<NameModel> nameModels)
        {
            // enumerate through the incoming names and print the name to output
            foreach (var sorted in _wrappedService.Sort(nameModels))
            {
                System.Console.WriteLine(sorted);
                yield return sorted;
            }
        }
    }
}
