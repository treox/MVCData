using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public static List<Person> AllPersons = new List<Person>
            {
                new Person { PersonId = 1, Name = "TestPerson1", PhoneNumber = "001234567", City = "TestCity1" },
                new Person { PersonId = 2, Name = "TestPerson2", PhoneNumber = "003554321", City = "TestCity2" },
                new Person { PersonId = 3, Name = "TestPerson3", PhoneNumber = "004466732", City = "TestCity3" }
            };

        public static List<Person> byNameList = new List<Person>();

        public static int NextId(int id)
        {
           return ++id;
        }

        public static void ReturnByNameOrCity(string name)
        {
            byNameList.Clear();

            foreach(Person personWithName in AllPersons)
            {
                if(personWithName.Name == name)
                {
                    byNameList.Add(personWithName);
                }

                if(personWithName.City == name)
                {
                    byNameList.Add(personWithName);
                }
            }
        }

        public static void DeletePerson(int id)
        {
            foreach(Person person in AllPersons)
            {
                if(person.PersonId == id)
                {
                    AllPersons.Remove(person);
                    break;
                }
            }
        }
    }
}
