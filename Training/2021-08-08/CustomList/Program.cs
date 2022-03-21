using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            AdultList people = new();

            Person mehmetPerson = new()
            {
                FirstName = "Mehmet",
                LastName = "Çavuş",
                Gender = Gender.Male,
                BirthDate = new DateTime(1996, 3, 13)
            };

            Person mervePerson = new()
            {
                FirstName = "Merve",
                LastName = "Demir",
                Gender = Gender.Female,
                BirthDate = new DateTime(2008, 7, 10)
            };

            Person unknownPerson = new()
            {
                FirstName = "Unknwon",
                LastName = "Unknown",
                Gender = Gender.Undefined,
                BirthDate =DateTime.MinValue
            };

            try
            {
                people.Add(mehmetPerson);
                Console.WriteLine("Mehmet person eklendi");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mehmet person eklenemedi. Ex: " + ex.Message);
            }


            try
            {
                people.Add(mervePerson);
                Console.WriteLine("mervePerson eklendi");
            }
            catch (Exception ex)
            {
                Console.WriteLine("mervePerson eklenemedi. Ex: " + ex.Message);
            }


            try
            {
                people.Add(unknownPerson);
                Console.WriteLine("unknownPerson eklendi");
            }
            catch (Exception ex)
            {
                Console.WriteLine("unknownPerson eklenemedi. Ex: " + ex.Message);
            }

            foreach (var item in people)
            {
                Console.WriteLine(item.FirstName);
            }


            Console.ReadLine();
        }
    }
}
