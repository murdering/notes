using System;
using System.Collections.Generic;
using System.Text;

namespace Array.Class
{
    public class PersonComparer : IComparer<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private PersonTypeEnum _personType;

        public PersonComparer(PersonTypeEnum personType)
        {
            this._personType = personType;
        }

        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;

            switch (_personType)
            {
                case PersonTypeEnum.FirstName:
                    int result = x.FirstName.CompareTo(y.FirstName);
                    if (result == 0)
                    {
                        result = x.LastName.CompareTo(y.LastName);
                    }
                    return result;

                case PersonTypeEnum.LastName:
                    result = string.Compare(x.LastName, y.LastName);
                    if (result == 0)
                    {
                        result = string.Compare(x.FirstName, y.FirstName);
                    }
                    return result;

                default:
                    throw new ArgumentException("wrong person type!");
            }
        }
    }
}