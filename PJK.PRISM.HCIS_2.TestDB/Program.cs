using PJK.PRISM.HCIS_2.Model;
using PJK.PRISM.HCIS_2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJK.PRISM.HCIS_2.TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to EF 2019");

            //insertPerson();
            getPersons();

            Console.ReadKey();


        }

        private static void getPersons()
        {

            using (var context = new HCISContext())
            {
                context.Database.Log = Console.WriteLine;


                var query = context.Persons.Where(p => p.Forename == "Sam");
                //var query = context.Persons.Where(p => p.Forename == "Sam")
                //    .OrderBy(p => p.Surname)
                //    .Skip(10)
                //    .Take(10);

                // var query = context.Persons.Where(p => p.Forename == "Paul").FirstOrDefault();
                //var query = context.Persons.ToList();
                //var query = context.Persons;
                foreach (Person p in query)
                {
                    Console.WriteLine(p.Surname + " " + p.Forename);
                }
            }

        }





        private static void insertPerson()
        {
            var person = new Person { Forename = "Paul", Surname = "Kane", NoOfDaysLeft = 30 };
            var person2 = new Person { Forename = "Sam", Surname = "Kane", NoOfDaysLeft = 20 };



            using (var context = new HCISContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Persons.Add(person);
                context.Persons.AddRange(new List<Person> { person, person2 });


                context.SaveChanges();
            }
        }





    }
}
