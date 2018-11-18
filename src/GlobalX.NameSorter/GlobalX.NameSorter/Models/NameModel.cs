using System;
using System.Linq;

namespace GlobalX.NameSorter
{

    /// <summary>
    /// Represents a person name as First Name and Last Name.
    /// NOTE: given name can have atleast 1 name and upto 3
    /// </summary>
    public sealed class NameModel
    {
        public NameModel(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Atleast 1 given name should be available");
            }

            var nameSplit = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (nameSplit.Length <= 1)
            {
                throw new ArgumentException("Atleast 1 given name should be available");
            }

            LastName = nameSplit[nameSplit.Length - 1];
            FirstName = string.Join(' ', nameSplit.Reverse().Skip(1).Reverse());
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
