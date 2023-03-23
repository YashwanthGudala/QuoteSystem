using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;

namespace QuoteSystemDataAccessTest
{
    class DataAccessTest
    {
        static void Main(string[] args)
        {
            //Testing add quote
            Console.ReadKey();

            //TestQuoteDataAccess.AddQuoteTest();


            //TestQuoteDataAccess.AddQuoteTest();
            //Console.ReadKey();


            //TestQuoteDataAccess.RemoveQuoteTest();


            //TestQuoteDataAccess.ViewQuoteTest();
            //Console.ReadKey();

            // TestQuoteDataAccess.ViewAllQuoteTest();


            //TestQuoteDataAccess.UpdateQuoteTest();

            //TestProspectDataAccess.ViewProspectTest();

            //TestProspectDataAccess.ViewAllProspectsTest();
            //TestCoveragesDataAccess.AddCoveragesTest();

            //TestCoveragesDataAccess.UpdateCoverageTest();
            //TestCoveragesDataAccess.DeleteCoveragesTest();
            //TestCoveragesDataAccess.GetAllCoveragesTest();
            TestCoveragesDataAccess.ViewSpecificCoveragesTest();

            Console.ReadLine();


        }

        
    }
}
