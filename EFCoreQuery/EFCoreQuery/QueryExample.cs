using EFCoreQuery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreQuery
{
    public class QueryExample
    {

        public void Qry()
        {
            //QueryAllCystomers();
            //QueryAllCystomersToList();
            //QueryAllCystomersWhere();
            QueryAllCystomersOrderBy();
        }

        public void QueryAllCystomers()
        {

            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer;

                foreach (var p in customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            //Query Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var customers = from c in db.Customer select c;

                foreach (var p in customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }


        }

        public void QueryAllCystomersToList()
        {

                    //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer.ToList();

                foreach (var p in customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            //Query Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var customers = (from c in db.Customer select c).ToList();

                foreach (var p in customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }

        }

        public void QueryAllCystomersWhere()
        {

            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                .Where(f => f.FirstName.StartsWith("A"))            
                                .ToList();

                foreach (var p in customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            //Query Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var customers = (from c in db.Customer
                                    where c.FirstName.StartsWith("A")
                                    select c).ToList();

                foreach (var p in customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }


        public void QueryAllCystomersOrderBy()
        {

            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                .OrderBy(f => f.FirstName)
                                .ToList();

                //var customers = db.Customer
                //    .OrderByDescending(f => f.FirstName)
                //    .ThenBy(f => f.LastName)
                //    .ThenByDescending(f=> f.Email)
                //    .ToList();

                foreach (var p in customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            //Query Syntax
            using (ChinookContext db = new ChinookContext())
            {
                //var customers = (from c in db.Customer
                //                    orderby c.FirstName
                //                    select c).ToList();

                var customers = (from c in db.Customer
                             orderby c.FirstName descending , c.LastName 
                             select c).ToList();

                foreach (var p in customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }

    }
}
