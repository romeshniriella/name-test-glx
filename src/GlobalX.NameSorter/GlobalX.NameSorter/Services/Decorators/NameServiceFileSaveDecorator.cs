using System.Collections.Generic;
using System.Linq;
using GlobalX.NameSorter.Abstractions;

namespace GlobalX.NameSorter
{

    public class NameServiceFileSaveDecorator : INameSortService
    {
        private readonly INameSortService _wrappedService;
        private readonly INameDataStore _nameDataStore;
        private readonly string _saveFileName;

        public NameServiceFileSaveDecorator(string saveFileName, INameSortService wrappedService, INameDataStore nameDataStore)
        {
            _wrappedService = wrappedService;
            _nameDataStore = nameDataStore;
            _saveFileName = saveFileName;
        }

        public IEnumerable<NameModel> Sort(IEnumerable<NameModel> nameModels)
        {
            // unwrap the incoming enumerable, otherwise it will do multi enumerations and result in weird output
            var names = _wrappedService.Sort(nameModels).ToList();

            // save the names in the file
            _nameDataStore.Save(_saveFileName, names);

            return names;
        }
    }
}
