using System;
using System.Collections.Generic;
using System.Linq;

namespace Week4Lab
{
    class Program
    {
        static void Print<T>(string label, IEnumerable<T> results)
        {
            Console.WriteLine(label);
            foreach (var result in results)
                Console.WriteLine("\t{0}", result);
        }

        static void Main(string[] args)
        {
            Company c = new Company();

            // 1. List the names of the employees who do not have a supervisor.
            // The results should combine FirstName and LastName into one string.
            var r1 = c.Employees.Where(e => e.SupervisorId == null)
                .OrderBy(e => e.FirstName)
                .Select(e => e.FirstName + " " + e.LastName)
                .Distinct();
            Print("Q1 (Method)", r1 );

            // 2. List the last names of the employees whose last name starts with D.
            // The results should be listed in alphabetic order without duplicates.
            var r2 = c.Employees.Where(e => e.LastName.StartsWith("D"))
                .OrderBy(e => e.LastName)
                .Select(e => e.LastName)
                .Distinct();
            Print("Q2 (Method)", r2);

            // 3. List the names of the employees who are on the project Blue.
            // The results should combine FirstName and LastName into one string.
            var r3 = c.Projects.Where(p => p.Name == "Blue")
                .Select(p => p.Members).Single();
            Print("Q3 (Method)", r3);

            // 4. Find Jane Doe's subordinates, i.e. the employees who are supervised by Jane Doe.
            var r4 = c.Employees.Where(p => p.SupervisorId == 2)
                .Select(e => e.FirstName + " " + e.LastName);
            Print("Q4 (Method)", r4);

            var r6 = (from e in c.Employees where e.FirstName == "Jane"  && e.LastName == "Doe" select e.Id)
                .Intersect((from p in c.Employees  select p));
            Print("Q5er (Query)", r6);

            // 5. Find the employee(s) who were hired in 2015 and worked on the project Blue.
            var r5 = (from e in c.Employees where e.DateHired.Year == 2015 select e)
                .Intersect((from p in c.Projects where p.Name == "Blue" select p.Members).Single());
            Print("Q5 (Query)", r5);
            
        }
    }
}
