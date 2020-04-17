using EFCoreQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreQuery
{
    public class ProjectionExample
    {

        public void Qry()
        {
            //WithoutProjection();
            ProjectToConcreteType();
        }


        public void WithoutProjection()
        {
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

        }


        public void ProjectToConcreteType()
        {

                   
            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {

                List<customerModel> Customers = db.Customer.
                                    Select(p => new customerModel { FirstName = p.FirstName, LastName = p.LastName, Email= p.Email })
                                    .ToList(); 

                foreach (var p in Customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }


            //Query Syntax
            using (ChinookContext db = new ChinookContext())
            {

                //List<customerModel> 
                List<customerModel> Customers = (from p in db.Customer
                                    select new customerModel { FirstName = p.FirstName, LastName = p.LastName, Email = p.Email })
                                .ToList();


                foreach (var p in Customers)
                {
                    Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
                }

            }


        }


public void ProjectToAnonymousType()
{


    //Method Syntax
    using (ChinookContext db = new ChinookContext())
    {

        var Customers = db.Customer.
                            Select(p => new customerModel { FirstName = p.FirstName, LastName = p.LastName, Email = p.Email })
                            .ToList();

        foreach (var p in Customers)
        {
            Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
        }

    }


    //Query Syntax
    using (ChinookContext db = new ChinookContext())
    {

        //List<customerModel> 
        var Customers = (from p in db.Customer
                        select new customerModel { FirstName = p.FirstName, LastName = p.LastName, Email = p.Email })
                        .ToList();


        foreach (var p in Customers)
        {
            Console.WriteLine("{0} {1} Email ID : {2}", p.FirstName, p.LastName, p.Email);
        }

    }


}

    }


    public class customerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
    }
}

