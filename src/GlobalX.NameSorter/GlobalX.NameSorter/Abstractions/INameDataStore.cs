using System.Collections.Generic;

namespace GlobalX.NameSorter.Abstractions
{
    /// <summary>
    /// Contains all the operations that can be done on a name data store. 
    /// In this test, data store is file based
    /// </summary>
    public interface INameDataStore
    {
        /// <summary>
        /// Return the list of names from the input file
        /// </summary>
        /// <returns></returns>
        IEnumerable<NameModel> Get();

        /// <summary>
        /// Save the sorted names to the output file
        /// </summary>
        /// <param name="sortedNames"></param>
        void Save(string saveFileName, IEnumerable<NameModel> sortedNames);
    }
}
