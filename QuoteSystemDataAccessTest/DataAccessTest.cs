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
            
            TestQuoteDataAccess.AddQuoteTest();
            Console.ReadKey();


        }

        
    }
}
