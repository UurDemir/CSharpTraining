using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class AdultList : IList<Person>
    {
        private Person[] people = null;
        private int size = 0;


        public AdultList()
        {
            people = Array.Empty<Person>();
        }

        public AdultList(int capacity)
        {
            people = capacity < 1 ? Array.Empty<Person>() : new Person[capacity];
        }


        public Person this[int index] { get => people[index]; set => people[index] = value; }

        public int Count => size;

        public bool IsReadOnly => false;


        //25 yaş ver üzeri adult sayılacak
        public void Add(Person item)
        {
            if (item.BirthDate > DateTime.Today.AddYears(-25))
                throw new Exception("25 yaşından küçükler listeye eklenemez.");

            if (item.Gender == Gender.Undefined)
                throw new Exception("Cinsiyet belirtilmesi gerekmektedir.");

            if (size == people.Length)
                EnsureSize(size+1);

            people[size++] = item;    
        }

        public void Clear()
        {
            people = Array.Empty<Person>();
        }

        public bool Contains(Person item)
        {
            return people.Contains(item);
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            Array.Copy(people, array, arrayIndex);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return people[i];
            }
        }

        public int IndexOf(Person item)
        {
            return Array.IndexOf(people, item);
        }

        public void Insert(int index, Person item)
        {
            if (size == people.Length)
                EnsureSize(size + 1);

            if (index < size)
            {
                Array.Copy(people, index, people, index + 1, size - index);
            }
            people[index] = item;
            size++;
        }

        public bool Remove(Person item)
        {
            int itemIndex = IndexOf(item);
            if (itemIndex >= 0)
            {
                RemoveAt(itemIndex);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            size--;
            if (index < size)
            {
                Array.Copy(people, index + 1, people, index, size - index);
            }
            people[size] = default;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return people[i];
            }
        }

        private void EnsureSize(int newSize)
        {
            Person[] newPeople = new Person[newSize];

            Array.Copy(people, newPeople, people.Length);

            people = newPeople;
        }
    }
}
