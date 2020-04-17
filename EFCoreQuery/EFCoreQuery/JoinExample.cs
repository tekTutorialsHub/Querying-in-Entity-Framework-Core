using EFCoreQuery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreQuery
{
    public class JoinExample
    {

        public void Qry()
        {
            //joinTwoTablesExample1();
            //joinTwoTablesExample2();


            //joinMultipleColumns();

            //joinThreeTablesMethodSyntax();
            //joinThreeTablesQuerySyntax();

            joinLeftQuerySyntaxExample1();
        }


        private void joinTwoTablesExample1()
        {


            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {

                var Track = db.Track
                    .Join(db.MediaType,
                        o => o.MediaTypeId,
                        i => i.MediaTypeId,
                        (o, i) =>
                        new
                        {
                            Name = o.Name,
                            Composer = o.Composer,
                            MediaType = i.Name
                        }
                    ).Take(5);

                foreach (var t in Track)
                {
                    Console.WriteLine("{0} {1} {2}", t.Name, t.Composer, t.MediaType);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();



            //Query Syntax
            using (ChinookContext db = new ChinookContext())
            {

                var Track = (from o in db.Track
                             join i in db.MediaType
                             on o.MediaTypeId equals i.MediaTypeId
                             select new
                             {
                                 Name = o.Name,
                                 Composer = o.Composer,
                                 MediaType = i.Name
                             }).Take(5);

                foreach (var t in Track)
                {
                    Console.WriteLine("{0} {1} {2}", t.Name, t.Composer, t.MediaType);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT TOP(@__p_0) [t].[Name], [t].[Composer], [m].[Name]
            //AS[MediaType]
            //FROM[Track] AS[t]
            //INNER JOIN[MediaType] AS[m] ON[t].[MediaTypeId] = [m].[MediaTypeId]

        }

        private void joinTwoTablesExample2()
        {


            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {

                var Track = db.Customer
                    .Join(db.Employee,
                        f => f.SupportRepId,
                        s => s.EmployeeId,
                        (f, s) =>
                        new
                        {
                            CustomerName = f.FirstName,
                            CustomerState = f.State,
                            EmployeeName = s.FirstName,
                            EmployeeState = s.State,
                        }
                    ).Take(5);

                foreach (var t in Track)
                {
                    Console.WriteLine("{0} {1} {2} {3}", t.CustomerName, t.CustomerState, t.EmployeeName, t.EmployeeState);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();



            //Query Syntax
            using (ChinookContext db = new ChinookContext())
            {

                var Track = (from f in db.Customer
                             join s in db.Employee
                             on f.SupportRepId equals s.EmployeeId
                             select new
                             {
                                 CustomerName = f.FirstName,
                                 CustomerState = f.State,
                                 EmployeeName = s.FirstName,
                                 EmployeeState = s.State,
                             }).Take(5);

                foreach (var t in Track)
                {
                    Console.WriteLine("{0} {1} {2} {3}", t.CustomerName, t.CustomerState, t.EmployeeName, t.EmployeeState);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT TOP(@__p_0) [c].[FirstName] AS[CustomerName], [c].[State] AS[CustomerState], [e].[FirstName] AS[EmployeeName], [e].[State]
            //AS[EmployeeState]
            //FROM[Customer] AS[c]
            //INNER JOIN[Employee] AS[e] ON[c].[SupportRepId] = [e].[EmployeeId]

        }

        private void joinMultipleColumns()
        {


            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {

                var Track = db.Customer
                    .Join(db.Employee,
                        f => new { f1 = f.SupportRepId.Value, f2 = f.State },
                        s => new { f1 = s.EmployeeId, f2 = s.State },
                        (f, s) =>
                        new
                        {
                            CustomerName = f.FirstName,
                            CustomerState = f.State,
                            EmployeeName = s.FirstName,
                            EmployeeState = s.State,
                        }
                    ).Take(5);

                foreach (var r in Track)
                {
                    Console.WriteLine("{0} {1} {2} {3}", r.CustomerName, r.CustomerState, r.EmployeeName, r.EmployeeState);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();



            //Query Syntax
            using (ChinookContext db = new ChinookContext())
            {

                var Track = (from f in db.Customer
                             join s in db.Employee
                             on new { f1 = f.SupportRepId.Value, f2 = f.State } equals new { f1 = s.EmployeeId, f2 = s.State }
                             select new
                             {
                                 CustomerName = f.FirstName,
                                 CustomerState = f.State,
                                 EmployeeName = s.FirstName,
                                 EmployeeState = s.State,
                             }).Take(5);

                foreach (var r in Track)
                {
                    Console.WriteLine("{0} {1} {2} {3}", r.CustomerName, r.CustomerState, r.EmployeeName, r.EmployeeState);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT TOP(@__p_0) [c].[FirstName] AS[CustomerName], [c].[State] AS[CustomerState], [e].[FirstName] AS[EmployeeName], [e].[State]
            //AS[EmployeeState]
            //FROM[Customer] AS[c]
            //INNER JOIN[Employee] AS[e] ON([c].[SupportRepId] = [e].[EmployeeId]) AND(([c].[State] = [e].[State]) OR([c].[State] IS NULL AND[e].[State] IS NULL))

        }

        private void joinThreeTablesMethodSyntax()
        {

            //Select Track.Name , Invoice.InvoiceDate, InvoiceLine.Quantity, InvoiceLine.UnitPrice
            //from Track
            //inner join InvoiceLine
            //On(Track.TrackId = InvoiceLine.TrackId)
            //inner join Invoice
            //On(Invoiceline.InvoiceId = Invoice.InvoiceId)
            //Where Track.name = 'Bohemian Rhapsody'


            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {

                var Track = db.Track
                            .Join(db.InvoiceLine,
                                    f => f.TrackId, s => s.TrackId,
                                    (f, s) => new { TrackName = f.Name, TrackId = f.TrackId, InvoiceId = s.InvoiceId, Quantity = s.Quantity, UnitPrice = s.UnitPrice }
                                )
                                .Join(db.Invoice,
                                    f => f.InvoiceId, s => s.InvoiceId,
                                    (f, s) => new { TrackName = f.TrackName, TrackId = f.TrackId, InvoiceId = f.InvoiceId, InvoiceDate = s.InvoiceDate, Quantity = f.Quantity, UnitPrice = f.UnitPrice }
                    ).Where(r => r.TrackName == "Bohemian Rhapsody")
                    .ToList();


                foreach (var r in Track)
                {
                    Console.WriteLine("{0} {1} {2} {3}", r.TrackName, r.InvoiceDate, r.Quantity, r.UnitPrice);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            using (ChinookContext db = new ChinookContext())
            {


                var Track = db.Track
                            .Join(db.InvoiceLine,
                                    f => f.TrackId, s => s.TrackId,
                                    (f, s) => new { TrackName = f.Name, TrackId = f.TrackId, InvoiceId = s.InvoiceId, Quantity = s.Quantity, UnitPrice = s.UnitPrice }
                                ).Where(r => r.TrackName == "Bohemian Rhapsody")
                                .Join(db.Invoice,
                                    f => f.InvoiceId, s => s.InvoiceId,
                                    (f, s) => new { TrackName = f.TrackName, TrackId = f.TrackId, InvoiceId = f.InvoiceId, InvoiceDate = s.InvoiceDate, Quantity = f.Quantity, UnitPrice = f.UnitPrice }
                                    )
                            .ToList();


                foreach (var r in Track)
                {
                    Console.WriteLine("{0} {1} {2} {3}", r.TrackName, r.InvoiceDate, r.Quantity, r.UnitPrice);
                }

            }


            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            using (ChinookContext db = new ChinookContext())
            {


                var Track = db.Track
                    .Join(db.InvoiceLine,
                            f => f.TrackId, s => s.TrackId,
                            (Track, InvoiceLine) => new { Track, InvoiceLine }
                        )
                        .Join(db.Invoice,
                            f => f.InvoiceLine.InvoiceId, s => s.InvoiceId,
                            (f, s) => new { TrackName = f.Track.Name, TrackId = f.Track.TrackId, InvoiceId = f.InvoiceLine.InvoiceId, InvoiceDate = s.InvoiceDate, Quantity = f.InvoiceLine.Quantity, UnitPrice = f.InvoiceLine.UnitPrice }
                            )
                    .Where(r => r.TrackName == "Bohemian Rhapsody")
                    .ToList();


                foreach (var r in Track)
                {
                    Console.WriteLine("{0} {1} {2} {3}", r.TrackName, r.InvoiceDate, r.Quantity, r.UnitPrice);
                }

            }


            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            //SELECT[t].[Name] AS[TrackName], [t].[TrackId], [i].[InvoiceId], [i0].[InvoiceDate], [i].[Quantity], [i].[UnitPrice]
            //FROM[Track] AS[t]
            //INNER JOIN[InvoiceLine] AS[i] ON[t].[TrackId] = [i].[TrackId]
            //INNER JOIN[Invoice] AS[i0] ON[i].[InvoiceId] = [i0].[InvoiceId]
            //WHERE[t].[Name] = N'Bohemian Rhapsody'

        }

        private void joinThreeTablesQuerySyntax()
        {
            using (ChinookContext db = new ChinookContext())
            {


                var Track = (from t in db.Track
                             join il in db.InvoiceLine
                             on t.TrackId equals il.TrackId
                             join i in db.Invoice
                             on il.InvoiceId equals i.InvoiceId
                             where t.Name == "Bohemian Rhapsody"
                             select (new
                             {
                                 TrackName = t.Name,
                                 TrackId = t.TrackId,
                                 InvoiceId = i.InvoiceId,
                                 InvoiceDate = i.InvoiceDate,
                                 Quantity = il.Quantity,
                                 UnitPrice = il.UnitPrice
                             })
                            ).ToList();

                foreach (var r in Track)
                {
                    Console.WriteLine("{0} {1} {2} {3}", r.TrackName, r.InvoiceDate, r.Quantity, r.UnitPrice);
                }

            }


            //SELECT[t].[Name] AS[TrackName], [t].[TrackId], [i0].[InvoiceId], [i0].[InvoiceDate], [i].[Quantity], [i].[UnitPrice]
            //FROM[Track] AS[t]
            //INNER JOIN[InvoiceLine] AS[i] ON[t].[TrackId] = [i].[TrackId]
            //INNER JOIN[Invoice] AS[i0] ON[i].[InvoiceId] = [i0].[InvoiceId]
            //WHERE[t].[Name] = N'Bohemian Rhapsody'

        }


        public void joinLeftQuerySyntaxExample1()
        {

            //Query Syntax 1

            Console.WriteLine("******************* Query Syntax 1 ******************* ");
            using (ChinookContext db = new ChinookContext())
            {

                var model = (from t in db.Track
                             join il in db.InvoiceLine on t.TrackId equals il.TrackId into j1

                             from j in j1.DefaultIfEmpty()
                             join i in db.Invoice on j.InvoiceId equals i.InvoiceId into j2

                             from r in j2.DefaultIfEmpty()
                             select new
                             {
                                 TrackName = t.Name,
                                 TrackId = t.TrackId,
                                 InvoiceId = r.InvoiceId,
                                 InvoiceDate = r.InvoiceDate,
                                 Quantity = j.Quantity,
                                 UnitPrice = j.UnitPrice
                             })
                                .Where(r => r.TrackName == "Bohemian Rhapsody")
                                .ToList();

                foreach (var item in model)
                {
                    Console.WriteLine("{0} {1} {2} {3}", item.TrackName, item.InvoiceDate, item.Quantity, item.UnitPrice);
                }

            }

            Console.WriteLine("Press any key to continue /Query Syntax 1");
            Console.ReadKey();


            //Query Syntax 2

            Console.WriteLine("******************* Query Syntax 2 ******************* ");
            using (ChinookContext db = new ChinookContext())
            {

                var model = (from t in db.Track

                             from il in db.InvoiceLine.Where(il => il.TrackId == t.TrackId).DefaultIfEmpty()
                             from i in db.Invoice.Where(i => i.InvoiceId == il.InvoiceId).DefaultIfEmpty()
                             select new
                             {
                                 TrackName = t.Name,
                                 TrackId = t.TrackId,
                                 InvoiceId = i.InvoiceId,
                                 InvoiceDate = i.InvoiceDate,
                                 Quantity = il.Quantity,
                                 UnitPrice = il.UnitPrice
                             })
                                .Where(r => r.TrackName == "Bohemian Rhapsody")
                                .ToList();

                foreach (var item in model)
                {
                    Console.WriteLine("{0} {1} {2} {3}", item.TrackName, item.InvoiceDate, item.Quantity, item.UnitPrice);
                }

            }

            Console.WriteLine("Press any key to continue /Query Syntax 1");
            Console.ReadKey();

   
            Console.WriteLine("Press any key to continue /Query Syntax 1");
            Console.ReadKey();

        }

    }

}

