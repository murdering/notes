using System;
using System.Collections.Generic;
using System.Text;

namespace Array.Class
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            if (other == null) return 1;

            int result = string.Compare(this.FirstName, other.FirstName);
            if (result == 0)
            {
                result = string.Compare(this.LastName, other.LastName);
            }

            return result;
        }
    }
}