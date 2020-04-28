using EFCoreQuery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreQuery
{
    public class IncludeExample
    {


        public void Qry()
        {

            //withoutInclude();
            //withInclude();
            //withThenInclude1();
            //withThenInclude2();
            //withThenInclude3();
            //withThenInclude4();

        }




        private void withoutInclude()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                .Where(c => c.FirstName.StartsWith("A"))
                                .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        private void withInclude()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                    .Include(c => c.Invoice)
                                    .Where(c => c.FirstName.StartsWith("A"))
                                    .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
                    foreach (var invoice in customer.Invoice)
                    {
                        Console.WriteLine("\t\t {0} {1}", invoice.InvoiceDate, invoice.Total);
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();



            //SELECT[c].[CustomerId], [c].[Address], [c].[City], [c].[Company], [c].[Country], [c].[Email], [c].[Fax], [c].[FirstName], [c].[LastName], [c].[Phone], [c].[PostalCode], [c].[State], [c].[SupportRepId], [i].[InvoiceId], [i].[BillingAddress], [i].[BillingCity], [i].[BillingCountry], [i].[BillingPostalCode], [i].[BillingState], [i].[CustomerId], [i].[InvoiceDate], [i].[Total]
            //FROM[Customer] AS[c]
            //LEFT JOIN[Invoice] AS[i] ON[c].[CustomerId] = [i].[CustomerId]
            //ORDER BY[c].[CustomerId], [i].[InvoiceId]
        }

        private void withThenInclude1()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                    .Include(c => c.Invoice)
                                        .ThenInclude(c => c.InvoiceLine)
                                    .Where(c => c.FirstName.StartsWith("A"))
                                    .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
                    foreach (var invoice in customer.Invoice)
                    {
                        Console.WriteLine("\t {0} {1}", invoice.InvoiceDate, invoice.Total);

                        foreach (var invoiceLine in invoice.InvoiceLine)
                        {
                            Console.WriteLine("\t\t {0} {1} {2}", invoiceLine.TrackId, invoiceLine.Quantity, invoiceLine.UnitPrice);
                        }
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();



        }


        private void withThenInclude2()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                    .Include(c => c.Invoice)
                                        .ThenInclude(c => c.InvoiceLine)
                                            .ThenInclude(c => c.Track)
                                                .ThenInclude(c => c.MediaType)
                                    .Where(c => c.FirstName.StartsWith("A"))
                                    .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
                    foreach (var invoice in customer.Invoice)
                    {
                        Console.WriteLine("\t {0} {1}", invoice.InvoiceDate, invoice.Total);

                        foreach (var invoiceLine in invoice.InvoiceLine)
                        {
                            Console.WriteLine("\t\t {0} {1} {2} {3}", invoiceLine.Track.Name, invoiceLine.Track.MediaType.Name, invoiceLine.Quantity, invoiceLine.UnitPrice);
                        }
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT[c].[CustomerId], [c].[Address], [c].[City], [c].[Company], [c].[Country], [c].[Email], [c].[Fax], [c].[FirstName], [c].[LastName], [c].[Phone], [c].[PostalCode], [c].[State], [c].[SupportRepId], [e].[EmployeeId], [e].[Address], [e].[BirthDate], [e].[City], [e].[Country], [e].[Email], [e].[Fax], [e].[FirstName], [e].[HireDate], [e].[LastName], [e].[Phone], [e].[PostalCode], [e].[ReportsTo], [e].[State], [e].[Title], [t1].[InvoiceId], [t1].[BillingAddress], [t1].[BillingCity], [t1].[BillingCountry], [t1].[BillingPostalCode], [t1].[BillingState], [t1].[CustomerId], [t1].[InvoiceDate], [t1].[Total], [t1].[InvoiceLineId], [t1].[InvoiceId0], [t1].[Quantity], [t1].[TrackId], [t1].[UnitPrice], [t1].[TrackId0], [t1].[AlbumId], [t1].[Bytes], [t1].[Composer], [t1].[GenreId], [t1].[MediaTypeId], [t1].[Milliseconds], [t1].[Name], [t1].[UnitPrice0], [t1].[MediaTypeId0], [t1].[Name0]
            //FROM[Customer] AS[c]
            //LEFT JOIN[Employee] AS[e] ON[c].[SupportRepId] = [e].[EmployeeId]
            //LEFT JOIN(
            //SELECT[i].[InvoiceId], [i].[BillingAddress], [i].[BillingCity], [i].[BillingCountry], [i].[BillingPostalCode], [i].[BillingState], [i].[CustomerId], [i].[InvoiceDate], [i].[Total], [t0].[InvoiceLineId], [t0].[InvoiceId] AS[InvoiceId0], [t0].[Quantity], [t0].[TrackId], [t0].[UnitPrice], [t0].[TrackId0], [t0].[AlbumId], [t0].[Bytes], [t0].[Composer], [t0].[GenreId], [t0].[MediaTypeId], [t0].[Milliseconds], [t0].[Name], [t0].[UnitPrice0], [t0].[MediaTypeId0], [t0].[Name0]
            //FROM [Invoice] AS [i]
            //LEFT JOIN (
            //SELECT[i0].[InvoiceLineId], [i0].[InvoiceId], [i0].[Quantity], [i0].[TrackId], [i0].[UnitPrice], [t].[TrackId] AS[TrackId0], [t].[AlbumId], [t].[Bytes], [t].[Composer], [t].[GenreId], [t].[MediaTypeId], [t].[Milliseconds], [t].[Name], [t].[UnitPrice] AS[UnitPrice0], [m].[MediaTypeId] AS[MediaTypeId0], [m].[Name] AS [Name0]
            //FROM [InvoiceLine] AS [i0]
            //INNER JOIN[Track] AS [t] ON[i0].[TrackId] = [t].[TrackId]

            //INNER JOIN [MediaType] AS[m] ON [t].[MediaTypeId] = [m].[MediaTypeId]
            //) AS[t0] ON[i].[InvoiceId] = [t0].[InvoiceId]
            //) AS[t1] ON[c].[CustomerId] = [t1].[CustomerId]
            //WHERE[c].[FirstName]
            //LIKE N'A%'
            //ORDER BY[c].[CustomerId], [t1].[InvoiceId], [t1].[InvoiceLineId], [t1].[TrackId0], [t1].[MediaTypeId0]

        }


        private void withThenInclude3()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                        .Include(c => c.Invoice)
                            .ThenInclude(c => c.InvoiceLine)
                                .ThenInclude(c => c.Track)
                                    .ThenInclude(c => c.MediaType)
                        .Include(c => c.SupportRep)
                        .Where(c => c.FirstName.StartsWith("A"))
                        .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName, customer.SupportRep.FirstName);
                    foreach (var invoice in customer.Invoice)
                    {
                        Console.WriteLine("\t {0} {1}", invoice.InvoiceDate, invoice.Total);

                        foreach (var invoiceLine in invoice.InvoiceLine)
                        {
                            Console.WriteLine("\t\t {0} {1} {2} {3}", invoiceLine.Track.Name, invoiceLine.Track.MediaType.Name, invoiceLine.Quantity, invoiceLine.UnitPrice);
                        }
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT[c].[CustomerId], [c].[Address], [c].[City], [c].[Company], [c].[Country], [c].[Email], [c].[Fax], [c].[FirstName], [c].[LastName], [c].[Phone], [c].[PostalCode], [c].[State], [c].[SupportRepId], [e].[EmployeeId], [e].[Address], [e].[BirthDate], [e].[City], [e].[Country], [e].[Email], [e].[Fax], [e].[FirstName], [e].[HireDate], [e].[LastName], [e].[Phone], [e].[PostalCode], [e].[ReportsTo], [e].[State], [e].[Title], [t1].[InvoiceId], [t1].[BillingAddress], [t1].[BillingCity], [t1].[BillingCountry], [t1].[BillingPostalCode], [t1].[BillingState], [t1].[CustomerId], [t1].[InvoiceDate], [t1].[Total], [t1].[InvoiceLineId], [t1].[InvoiceId0], [t1].[Quantity], [t1].[TrackId], [t1].[UnitPrice], [t1].[TrackId0], [t1].[AlbumId], [t1].[Bytes], [t1].[Composer], [t1].[GenreId], [t1].[MediaTypeId], [t1].[Milliseconds], [t1].[Name], [t1].[UnitPrice0], [t1].[MediaTypeId0], [t1].[Name0]
            //FROM[Customer] AS[c]
            //LEFT JOIN[Employee] AS[e] ON[c].[SupportRepId] = [e].[EmployeeId]
            //LEFT JOIN(
            //SELECT[i].[InvoiceId], [i].[BillingAddress], [i].[BillingCity], [i].[BillingCountry], [i].[BillingPostalCode], [i].[BillingState], [i].[CustomerId], [i].[InvoiceDate], [i].[Total], [t0].[InvoiceLineId], [t0].[InvoiceId] AS[InvoiceId0], [t0].[Quantity], [t0].[TrackId], [t0].[UnitPrice], [t0].[TrackId0], [t0].[AlbumId], [t0].[Bytes], [t0].[Composer], [t0].[GenreId], [t0].[MediaTypeId], [t0].[Milliseconds], [t0].[Name], [t0].[UnitPrice0], [t0].[MediaTypeId0], [t0].[Name0]
            //FROM [Invoice] AS [i]
            //LEFT JOIN (
            //SELECT[i0].[InvoiceLineId], [i0].[InvoiceId], [i0].[Quantity], [i0].[TrackId], [i0].[UnitPrice], [t].[TrackId] AS[TrackId0], [t].[AlbumId], [t].[Bytes], [t].[Composer], [t].[GenreId], [t].[MediaTypeId], [t].[Milliseconds], [t].[Name], [t].[UnitPrice] AS[UnitPrice0], [m].[MediaTypeId] AS[MediaTypeId0], [m].[Name] AS [Name0]
            //FROM [InvoiceLine] AS [i0]
            //INNER JOIN[Track] AS [t] ON[i0].[TrackId] = [t].[TrackId]

            //INNER JOIN [MediaType] AS[m] ON [t].[MediaTypeId] = [m].[MediaTypeId]
            //) AS[t0] ON[i].[InvoiceId] = [t0].[InvoiceId]
            //) AS[t1] ON[c].[CustomerId] = [t1].[CustomerId]
            //WHERE[c].[FirstName]
            //LIKE N'A%'
            //ORDER BY[c].[CustomerId], [t1].[InvoiceId], [t1].[InvoiceLineId], [t1].[TrackId0], [t1].[MediaTypeId0]

        }


        private void withThenInclude4()
        {

            using (ChinookContext db = new ChinookContext())
            {


                var customers = db.Customer
                    .Include(c => c.Invoice
                            .Where(f => f.Total > 10))
                        .ThenInclude(c => c.InvoiceLine)
                            .ThenInclude(c => c.Track)
                                .ThenInclude(c => c.MediaType)
                    .Include(c => c.SupportRep)
                    .Where(c => c.FirstName.StartsWith("A"))
                    .ToList();



                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName, customer.SupportRep.FirstName);
                    foreach (var invoice in customer.Invoice)
                    {
                        Console.WriteLine("\t {0} {1}", invoice.InvoiceDate, invoice.Total);

                        foreach (var invoiceLine in invoice.InvoiceLine)
                        {
                            Console.WriteLine("\t\t {0} {1} {2} {3}", invoiceLine.Track.TrackId, invoiceLine.Track.MediaType.Name, invoiceLine.Quantity, invoiceLine.UnitPrice);
                        }
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


        }



        private void withThenInclude5()
        {

            //db.Parent
            //    .Include(a => a.Child).ThenInclude(b => b.SubChild1)
            //    .Include(a => a.Child).ThenInclude(b => b.SubChild2);


            //db.Invoice
            //    .Include(x => x.Items)
            //        .ThenInclude(x => x.Department)
            //            .ThenInclude(x => x.location)

            //    .Include(x => x.Items)
            //        .ThenInclude(x => x.Store)
            //            .ThenInclude(x => x.Manager)

            //    .Include(x => x.Items)
            //        .ThenInclude(x => x.Model)
            //            .ThenInclude(x => x.Color);
                        

        }

        public class Parent
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual Child Child { get; set; }
        }

        public class Child
        {
            public int Id { get; set; }
            public string ChildName { get; set; }

            public virtual List<SubChild1> SubChild1 { get; set; }

            public virtual List<SubChild2> SubChild2 { get; set; }
        }

        public class SubChild1
        {
            public int Id { get; set; }
        }

        public class SubChild2
        {
            public int Id { get; set; }
        }


    }
}
