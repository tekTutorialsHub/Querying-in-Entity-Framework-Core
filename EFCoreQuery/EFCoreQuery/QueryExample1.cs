using EFCoreQuery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreQuery
{
    public class QueryExample1
    {
        

        public void Qry()
        {
            //Query1();
            //Query2();
            //Query3();
            //Query4();
            //Query5();
            Query6();

        }

        public void Query1()
        {

            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var result = db.Album
                                .Include(a => a.Track)
                                .Where(a => a.Title.StartsWith("AL"))
                                .ToList();


                foreach (var album in result)
                {
                    Console.WriteLine("{0}", album.Title);

                    foreach (var track in album.Track)
                    {
                        Console.WriteLine("\t\t{0}", track.Name);
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT [a].[AlbumId], [a].[ArtistId], [a].[Title], [t].[TrackId], [t].[AlbumId], [t].[Bytes], [t].[Composer], [t].[GenreId], [t].[MediaTypeId], [t].[Milliseconds], [t].[Name], [t].[UnitPrice]
            //FROM [Album] AS [a]
            //LEFT JOIN [Track] AS [t] ON [a].[AlbumId] = [t].[AlbumId]
            //WHERE [a].[Title] LIKE N'AL%'
            //ORDER BY [a].[AlbumId], [t].[TrackId]

        }



        public void Query2()
        {

            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var result = db.Album
                            .Where(a => a.Title.StartsWith("AL"))
                            .Select(a => new
                            {
                                a.Title,
                                Track=a.Track
                            })
                            .ToList();


                foreach (var album in result)
                {
                    Console.WriteLine("{0}", album.Title);

                    foreach (var track in album.Track)
                    {
                        Console.WriteLine("\t\t{0}", track.Name);
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT [a].[Title], [a].[AlbumId], [t].[TrackId], [t].[AlbumId], [t].[Bytes], [t].[Composer], [t].[GenreId], [t].[MediaTypeId], [t].[Milliseconds], [t].[Name], [t].[UnitPrice]
            //FROM [Album] AS [a]
            //LEFT JOIN [Track] AS [t] ON [a].[AlbumId] = [t].[AlbumId]
            //WHERE [a].[Title] LIKE N'AL%'
            //ORDER BY [a].[AlbumId], [t].[TrackId]

        }


        public void Query3()
        {

            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var result = db.Album
                            .Where(a => a.Title.StartsWith("AL"))
                            .Select(a => new
                            {
                                Album = a,
                                Track = a.Track.Where(f=> f.Name.StartsWith("A"))
                            })
                            .ToList();


                foreach (var model in result)
                {
                    Console.WriteLine("{0}", model.Album.Title);

                    foreach (var track in model.Track)
                    {
                        Console.WriteLine("\t\t{0}", track.Name);
                    }

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            //SELECT [a].[AlbumId], [a].[ArtistId], [a].[Title], [t0].[TrackId], [t0].[AlbumId], [t0].[Bytes], [t0].[Composer], [t0].[GenreId], [t0].[MediaTypeId], [t0].[Milliseconds], [t0].[Name], [t0].[UnitPrice]
            //FROM [Album] AS [a]
            //LEFT JOIN (
            //    SELECT [t].[TrackId], [t].[AlbumId], [t].[Bytes], [t].[Composer], [t].[GenreId], [t].[MediaTypeId], [t].[Milliseconds], [t].[Name], [t].[UnitPrice]
            //    FROM [Track] AS [t]
            //    WHERE [t].[Name] LIKE N'A%'
            //) AS [t0] ON [a].[AlbumId] = [t0].[AlbumId]
            //WHERE [a].[Title] LIKE N'AL%'
            //ORDER BY [a].[AlbumId], [t0].[TrackId]


        }



        public void Query4()
        {

            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var result = db.Album
                            .Where(a => a.Title.StartsWith("AL"))
                            .Select(a => new
                            {
                                Album = a,
                                Track = a.Track.FirstOrDefault()
                            })
                            .ToList();


                foreach (var model in result)
                {
                    Console.WriteLine("{0}\t: {1}", model.Album.Title, model.Track.Name );

                    //foreach (var track in model.Track)
                    //{
                    //    Console.WriteLine("\t\t{0}", track.Name);
                    //}

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

              //SELECT [a].[AlbumId], [a].[ArtistId], [a].[Title], [t1].[TrackId], [t1].[AlbumId], [t1].[Bytes], [t1].[Composer], [t1].[GenreId], [t1].[MediaTypeId], [t1].[Milliseconds], [t1].[Name], [t1].[UnitPrice]
              //FROM [Album] AS [a]
              //LEFT JOIN (
                  //SELECT [t0].[TrackId], [t0].[AlbumId], [t0].[Bytes], [t0].[Composer], [t0].[GenreId], [t0].[MediaTypeId], [t0].[Milliseconds], [t0].[Name], [t0].[UnitPrice]
                  //FROM (
                  //    SELECT [t].[TrackId], [t].[AlbumId], [t].[Bytes], [t].[Composer], [t].[GenreId], [t].[MediaTypeId], [t].[Milliseconds], [t].[Name], [t].[UnitPrice], ROW_NUMBER() OVER(PARTITION BY [t].[AlbumId] ORDER BY [t].[TrackId]) AS [row]
                  //    FROM [Track] AS [t]
                  //) AS [t0]
                  //WHERE [t0].[row] <= 1
              //) AS [t1] ON [a].[AlbumId] = [t1].[AlbumId]
              //WHERE [a].[Title] LIKE N'AL%'

        }


        public void Query5()
        {
            //DOes not work
            //InvalidOperationExceptio


            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var result = db.Track
                            .GroupBy(t => t.AlbumId)
                            .Select(t=> t.FirstOrDefault())
                            .ToList();


                foreach (var model in result)
                {
                    Console.WriteLine("{0}", model.TrackId);

                    //foreach (var track in model.Track)
                    //{
                    //    Console.WriteLine("\t\t{0}", track.Name);
                    //}

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


        }

        public void Query6()
        {


            //Method Syntax
            using (ChinookContext db = new ChinookContext())
            {
                var result = db.Track
                            .ToLookup(p=> p.Album.AlbumId)
                            .ToList();


                foreach (var model in result)
                {
                    Console.WriteLine("{0}", model.Key);

                    //foreach (var track in model.Track)
                    //{
                    //    Console.WriteLine("\t\t{0}", track.Name);
                    //}

                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


        }
    }
}
