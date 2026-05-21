using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    public class Contact : IComparable<Contact>, IEquatable<Contact>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public Contact(string name, string city, string phoneNumber)
        {
            Name = name;
            City = city;
            PhoneNumber = phoneNumber;
        }

        public int CompareTo(Contact other)
        {
            int result = City.CompareTo(other.City);
            if (result == 0)
            {
                result = Name.CompareTo(other.Name);
            }
            if (result == 0)
            {
                result = PhoneNumber.CompareTo(other.PhoneNumber);
            }
            return result;
        }
        public override string ToString()
        {
            return $" {Name} | {City} | {PhoneNumber}";
        }
        public override bool Equals(object? obj)
        {
          
            return Equals(obj as Contact);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, City, PhoneNumber);
        }

        public bool Equals(Contact? other)
        {
            if (other is null)
                return false;

            return Name == other.Name
                && City == other.City
                && PhoneNumber == other.PhoneNumber;
        }
    }
}
