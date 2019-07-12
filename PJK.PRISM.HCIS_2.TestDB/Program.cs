using PJK.PRISM.HCIS_2.Model;
using PJK.PRISM.HCIS_2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace PJK.PRISM.HCIS_2.TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to EF 2019");

            projectionPersonGraph();
            //getPersonGraph();
            //addSomeLeave();

            //insertPerson();
            //getPersons();

            Console.ReadKey();


        }


        private static void projectionPersonGraph()
        {
            using (var context = new HCISContext())
            {
                context.Database.Log = Console.WriteLine;


                var persons = context.Persons
                    .Select(k => new { k.Surname, k.Forename, k.LeaveItems })
                    .ToList();




            }



            }



            private static void getPersonGraph()
        {
            using (var context = new HCISContext())
            {
                context.Database.Log = Console.WriteLine;

                //var person = context.Persons.FirstOrDefault();

                //Eager Load
                var person = context.Persons.Include(p => p.LeaveItems ).FirstOrDefault();

                //Explicit Loading
                var person1 = context.Persons.FirstOrDefault();
                context.Entry(person1).Collection(l => l.LeaveItems).Load();

                //LAZY LOADING - BE CAREFUL FOR PERFORMACE
                //Mark the property as virtual 
                Console.WriteLine($"Found {0}, {1}" +  person.Surname, person.Id);

            }
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

        private static void addSomeLeave()
        {


            using (var context = new HCISContext())
            {
                context.Database.Log = Console.WriteLine;

                var person = context.Persons.FirstOrDefault();

                var leave1 = new Leave { FromDate = new DateTime(2019, 1, 1), ToDate = new DateTime(2019, 1, 3), NoWorkingDays = 1, LeaveTypeId = LeaveType.AnnualLeave };
                var leave2 = new Leave { FromDate = new DateTime(2019, 3, 1), ToDate = new DateTime(2019, 3, 3), NoWorkingDays = 1, LeaveTypeId = LeaveType.AnnualLeave };

                person.LeaveItems.Add(leave1);
                person.LeaveItems.Add(leave2);

                context.SaveChanges();
            }


        }








        private static void removePerson()
        {
            using (var context = new HCISContext())
            {
                var person = context.Persons.FirstOrDefault();
                context.Persons.Remove(person);
            }


        }

        private static void removePerson2()
        {
            //use a stored procedure 
            using (var context = new HCISContext())
            {
                var person = context.Persons.FirstOrDefault();

                context.Entry(person).State = EntityState.Deleted;

                int key = 1;
                context.Database.ExecuteSqlCommand("exec deletePerson {0}", key);

                context.SaveChanges();

            }


        }





        private static void useFindandSQL()
        {

            using (var context = new HCISContext())
            {
                //locate using KEY
                var person = context.Persons.Find(1);

                //use SQL 
                var person2 = context.Persons.SqlQuery("Select * From Person");
                var person3 = context.Persons.SqlQuery("exec sp_who");
             }


        }


        private static void updatePerson()
        {
           // var person = new Person { Forename = "Paul", Surname = "Kane", NoOfDaysLeft = 30 };
            var person2 = new Person { Forename = "Sam", Surname = "Kane", NoOfDaysLeft = 20 };

            Person person;
            using (var context = new HCISContext())
            {
                person = context.Persons.FirstOrDefault();

            }

            person.Surname = "Test";
            

                using (var context = new HCISContext())
            {

               

                context.Persons.Attach(person);
                context.Entry(person).State = EntityState.Modified;

                context.Database.Log = Console.WriteLine;
                context.SaveChanges();
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
