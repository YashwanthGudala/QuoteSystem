using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemBusiness;
namespace QuoteSystemBusinessTest
{
    public class TestRatingEngine
    {
        static void Main(string[] args)
        {


            //RatingEngine.LoadMetaData();
            //RatingEngine.DisplayAllTables();

            //float res = RatingEngine.LookupRate("Deductible Factor", "250", "BI");

            //Console.WriteLine(res);

            //res = RatingEngine.LookupRate("Limit Factor", "25000", "50000");

            //Console.WriteLine(res);

            //res = RatingEngine.LookupRate("Premises Operations Loss Cost", "27025", "001");

            //Console.WriteLine(res);

            RatingEngine.GetPremiumTest();
            Console.Read();

        }
    }
}
