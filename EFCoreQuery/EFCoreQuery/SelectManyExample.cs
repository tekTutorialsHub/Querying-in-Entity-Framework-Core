using EFCoreQuery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreQuery
{
    public class SelectManyExample
    {

        public void Qry()
        {

            // Query1();
            // Query2();
            Query3();
        }


        public void Query1()
        {

            //SELECT  FirstName , InvoiceDate, Total
            //FROM Customer  C
            //LEFT JOIN Invoice I
            //ON C.CustomerId  = I.CustomerId
            //WHERE FirstName LIKE 'A%'
            //ORDER BY C.CustomerId, i.InvoiceId

            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                    .Where(c => c.FirstName.StartsWith("A"))
                                    .Select(c =>
                                       new
                                       {
                                           c.FirstName,
                                           c.Invoice,
                                       }
                                    )
                                    .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0}", customer.FirstName);
                    foreach (var invoice in customer.Invoice)
                    {
                        Console.WriteLine("\t\t {0} {1}", invoice.InvoiceDate, invoice.Total);
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            //SELECT [c].[FirstName], [c].[CustomerId], [i].[InvoiceId], [i].[BillingAddress], [i].[BillingCity], [i].[BillingCountry], [i].[BillingPostalCode], [i].[BillingState], [i].[CustomerId], [i].[InvoiceDate], [i].[Total]
            // FROM [Customer] AS [c]
            // LEFT JOIN [Invoice] AS [i] ON [c].[CustomerId] = [i].[CustomerId]
            // WHERE [c].[FirstName] LIKE N'A%'
            // ORDER BY [c].[CustomerId], [i].[InvoiceId]

        }



        public void Query2()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                    .Where(c => c.FirstName.StartsWith("A"))
                                    .SelectMany(c => c.Invoice, (c, i) =>
                                       new
                                       {
                                           c.FirstName,
                                           i.InvoiceDate,
                                           i.Total
                                       }
                                    )
                                    .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1} {2}", customer.FirstName, customer.InvoiceDate, customer.Total);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT [c].[FirstName], [i].[InvoiceDate], [i].[Total]
            //FROM [Customer] AS [c]
            //INNER JOIN [Invoice] AS [i] ON [c].[CustomerId] = [i].[CustomerId]
            //WHERE [c].[FirstName] LIKE N'A%'


        }


        public void Query3()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var customers = db.Customer
                                .Where(c => c.FirstName.StartsWith("A"))
                                .SelectMany(c => c.Invoice, (c, i) =>
                                    new
                                    {
                                        c.FirstName,
                                        i.InvoiceDate,
                                        i.Total,
                                        i.InvoiceLine
                                    }
                                )
                                .SelectMany(p => p.InvoiceLine, (o, i) =>
                                    new
                                    {
                                        o.FirstName,
                                        o.InvoiceDate,
                                        o.Total,
                                        i.Quantity,
                                        i.UnitPrice,
                                        TrackName = i.Track.Name,
                                        i.Track.Album.Title
                                    }
                                )
                                .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", customer.FirstName, customer.InvoiceDate, customer.TrackName, customer.Title, customer.Quantity, customer.UnitPrice, customer.Total);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT [c].[FirstName], [i].[InvoiceDate], [i].[Total], [i0].[Quantity], [i0].[UnitPrice], [t].[Name] AS [TrackName], [a].[Title]
            //FROM [Customer] AS [c]
            //INNER JOIN [Invoice] AS [i] ON [c].[CustomerId] = [i].[CustomerId]
            //INNER JOIN [InvoiceLine] AS [i0] ON [i].[InvoiceId] = [i0].[InvoiceId]
            //INNER JOIN [Track] AS [t] ON [i0].[TrackId] = [t].[TrackId]
            //LEFT JOIN [Album] AS [a] ON [t].[AlbumId] = [a].[AlbumId]
            //WHERE [c].[FirstName] LIKE N'A%'



        }


    }
}
