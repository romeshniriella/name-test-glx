using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalX.NameSorter.Abstractions;

namespace GlobalX.NameSorter.Abstractions
{

    /// <summary>
    /// Contains operations for the name sorting service
    /// </summary>
    public interface INameSortService
    {
        /// <summary>
        /// Sorts the given names by last name and then by first name
        /// </summary>
        /// <param name="nameModels"></param>
        /// <returns></returns>
        IEnumerable<NameModel> Sort(IEnumerable<NameModel> nameModels);
    }
}
