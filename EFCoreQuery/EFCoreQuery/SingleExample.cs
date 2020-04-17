using EFCoreQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreQuery
{
    public class SingleExample
    {


        public void Qry()
        {

            //singleRecordExists();
            //singleRecordNotExists();
            //singleMultipeRecordExists();


            //singleOrDefaultRecordExists();
            //singleOrDefaultRecordNotExists();
            //singleOrDefaultMultipeRecordExists();


            firstRecordExists();
            firstRecordNotExists();
            firstMultipeRecordExists();


            //firstOrDefaultRecordExists();
            //firstOrDefaultRecordNotExists();
            //firstOrDefaultMultipeRecordExists();

        }


        public void singleRecordExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Name == "Bohemian Rhapsody").Single();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown "+ ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void singleRecordNotExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Name == "Love Kills").Single();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void singleMultipeRecordExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Composer== "Mercury, Freddie").Single();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }



        public void singleOrDefaultRecordExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Name == "Bohemian Rhapsody").SingleOrDefault();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void singleOrDefaultRecordNotExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Name == "Love Kills").SingleOrDefault();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void singleOrDefaultMultipeRecordExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Composer == "Mercury, Freddie").SingleOrDefault();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }




        public void firstRecordExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Name == "Bohemian Rhapsody").First();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void firstRecordNotExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Name == "Love Kills").First();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void firstMultipeRecordExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Composer == "Mercury, Freddie")
                        .First();

                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }



        public void firstOrDefaultRecordExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Name == "Bohemian Rhapsody").FirstOrDefault();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void firstOrDefaultRecordNotExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Name == "Love Kills").FirstOrDefault();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void firstOrDefaultMultipeRecordExists()
        {
            using (ChinookContext db = new ChinookContext())
            {
                try
                {
                    var track = db.Track.Where(f => f.Composer == "Mercury, Freddie").FirstOrDefault();
                    if (track != null)
                    {
                        Console.WriteLine("{0} {1} ", track.Name, track.Composer);
                    }
                    else
                    {
                        Console.WriteLine("Track not found");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Track not found but exception thrown " + ex.Message);

                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

    }


}
