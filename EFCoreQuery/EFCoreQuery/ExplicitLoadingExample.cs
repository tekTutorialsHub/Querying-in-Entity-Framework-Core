using EFCoreQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreQuery
{
    public class ExplicitLoadingExample
    {
        public void Qry()
        {

           //ExplicitLoading1();
          //  ExplicitLoading2();
           ExplicitLoading3();
        }

        private void ExplicitLoading1()
        {


            using (ChinookContext db = new ChinookContext())
            {

                var Tracks = db.Track.Take(5).ToList();



                foreach (var track in Tracks)
                {
                    db.Entry(track).Reference(t => t.Album).Load();
                    db.Entry(track.Album).Reference(t => t.Artist).Load();

                    Console.WriteLine("{0} {1} {2}", track.Album.Title, track.Name, track.Album.Artist.Name);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        //SELECT TOP(@__p_0) [t].[TrackId], [t].[AlbumId], [t].[Bytes], [t].[Composer], [t].[GenreId], [t].[MediaTypeId], [t].[Milliseconds], [t].[Name], [t].[UnitPrice]
        //FROM [Track] AS [t]

        //SELECT [a].[AlbumId], [a].[ArtistId], [a].[Title]
        //FROM [Album] AS [a]
        //WHERE [a].[AlbumId] = @__p_0

        //SELECT [a].[ArtistId], [a].[Name]
        //FROM [Artist] AS [a]
        //WHERE [a].[ArtistId] = @__p_0


        }



        private void ExplicitLoading2()
        {


            using (ChinookContext db = new ChinookContext())
            {

                var Albums = db.Album.Take(5).ToList();

                foreach (var album in Albums)
                {
                    db.Entry(album).Collection(t => t.Track).Load();
                    db.Entry(album).Reference(t => t.Artist).Load();

                    Console.WriteLine("{0} {1}", album.Title, album.Artist.Name);

                    foreach (var track in album.Track)
                    {
                        Console.WriteLine("\t\t\t{0}", track.Name);
                    }
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            //SELECT TOP(@__p_0) [a].[AlbumId], [a].[ArtistId], [a].[Title]
            //FROM [Album] AS [a]

            //SELECT [t].[TrackId], [t].[AlbumId], [t].[Bytes], [t].[Composer], [t].[GenreId], [t].[MediaTypeId], [t].[Milliseconds], [t].[Name], [t].[UnitPrice]
            //FROM [Track] AS [t]
            //WHERE [t].[AlbumId] = @__p_0

            //SELECT [a].[ArtistId], [a].[Name]
            //FROM [Artist] AS [a]
            //WHERE [a].[ArtistId] = @__p_0

        }


        private void ExplicitLoading3()
        {

            //This is not allowed
            //db.Entry(album).Collection(t => t.Track.Where(f => f.Name.StartsWith("A"))).Load();

            using (ChinookContext db = new ChinookContext())
            {

                var Albums = db.Album.Take(5).ToList();

                foreach (var album in Albums)
                {
                    
                    db.Entry(album).Collection(t => t.Track).Query().Where(f => f.Name.Contains("The")).Load();
                    db.Entry(album).Reference(t => t.Artist).Query().Load();

                    //Also works
                    //db.Entry(album).Collection(t => t.Track).Query().Where(f => f.Name.Contains("The")).ToList();
                    //db.Entry(album).Reference(t => t.Artist).Query().ToList();

                    Console.WriteLine("{0} {1}", album.Title, album.Artist.Name);

                    foreach (var track in album.Track)
                    {
                        Console.WriteLine("\t\t\t{0}", track.Name);
                    }
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


    }
}
