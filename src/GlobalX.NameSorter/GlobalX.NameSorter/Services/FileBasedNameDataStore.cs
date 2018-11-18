using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalX.NameSorter.Abstractions;

namespace GlobalX.NameSorter
{
    public class FileBasedNameDataStore : INameDataStore
    {
        private readonly string _filePath;

        public FileBasedNameDataStore(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<NameModel> Get()
        {
            return File.ReadAllLines(_filePath).Select(fullName => new NameModel(fullName));
        }

        public void Save(string saveFileName, IEnumerable<NameModel> sortedNames)
        {
            File.WriteAllLines(saveFileName, sortedNames.Select(x => x.ToString()).ToArray());
        }

    }
}
