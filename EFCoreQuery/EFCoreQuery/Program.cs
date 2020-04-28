using EFCoreQuery;
using System;

namespace EFCoreQuery
{
    class Program
    {
        static void Main(string[] args)
        {

            QueryExample queryExample = new QueryExample();
            //queryExample.Qry();

            SingleExample qrySingle = new SingleExample();
            //qrySingle.Qry();

            FindExample qryFind = new FindExample();
            //qryFind.Qry();

            ProjectionExample prjQry = new ProjectionExample();
            //prjQry.Qry();


            JoinExample joinQry = new JoinExample();
            //joinQry.Qry();


            IncludeExample includeExample = new IncludeExample();
            //includeExample.Qry();

            SelectManyExample selectManyQry = new SelectManyExample();
            //selectManyQry.Qry();

            ExplicitLoadingExample ex = new ExplicitLoadingExample();
            ex.Qry();




            //Query Examples
            QueryExample1 Qry1 = new QueryExample1();
            //Qry1.Qry();

        }


    }
}
