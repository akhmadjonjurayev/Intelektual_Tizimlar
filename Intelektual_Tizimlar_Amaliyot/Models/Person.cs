using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Intelektual_Tizimlar_Amaliyot.Models
{
    public class Person : IOrderedEnumerable<Person>
    {
        public Guid PersonId { get; set; }

        public string PersonName { get; set; }

        public int Sequence { get; set; }

        public Person[] data = new Person[2] {new Person(), new Person() };

        public IOrderedEnumerable<Person> CreateOrderedEnumerable<TKey>(Func<Person, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return descending ?
                  data.OrderByDescending(keySelector, comparer)
                : data.OrderBy(keySelector, comparer);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
