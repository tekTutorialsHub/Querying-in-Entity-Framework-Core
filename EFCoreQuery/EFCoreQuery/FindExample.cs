using EFCoreQuery.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreQuery
{
    public class FindExample
    {

        public void Qry()
        {
            findByID();
            findByCompositeID();
        }

        private void findByID()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var employee = db.Employee.Find(1);

                if (employee !=null)
                {
                    Console.WriteLine("{0} {1} Email @ {2}", employee.FirstName, employee.LastName, employee.Email);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        private void findByCompositeID()
        {

            using (ChinookContext db = new ChinookContext())
            {
                var playlistTrack = db.PlaylistTrack.Find(1,1);

                if (playlistTrack != null)
                {
                    Console.WriteLine("{0} {1} ", playlistTrack.PlaylistId, playlistTrack.TrackId);
                }

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

    }
}
