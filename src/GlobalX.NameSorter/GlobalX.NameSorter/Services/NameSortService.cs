using System.Collections.Generic;
using System.Linq;
using GlobalX.NameSorter.Abstractions;

namespace GlobalX.NameSorter
{

    public class NameSortService : INameSortService
    {
        public IEnumerable<NameModel> Sort(IEnumerable<NameModel> nameModels)
        {
            // order the names by last name and then by first name
            return nameModels
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName);
        }
    }
}
