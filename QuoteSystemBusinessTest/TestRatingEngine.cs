using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemBusiness;
using QuoteSystemDataModel;

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

            // RatingEngine.GetPremiumTest();

            Quote quote = GetSampleQuote();
            
            float res = RatingEngine.RateQuote(quote);

            Console.WriteLine("Premium = " +res);

            Console.Read();

        }

        public static Quote GetSampleQuote()
        {
            Address Address = new Address()
            {
                FirstLine = "Cosmos Bank",
                SecondLine = "ECIL",
                City = "Hyd",
                State = "telangana",
                ZipCode = "505301",
            };

            List<Business> businesses = new List<Business>();


            Business business = new Business()
            {
                IndustryType = "27025",
                Territory = "001",
                Exposure = 2000,
                Address = Address,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="BI",
                          Deductible=250,
                          OccuranceLimit=25000,
                          AggregateLimit=50000,
                          CoveragePremium=0d

                     }
                }

            };
            Address Address2 = new Address()
            {
                FirstLine = "Toopran",
                SecondLine = "ECIL",
                City = "Hyd",
                State = "telangana",
                ZipCode = "505301",
            };
            Business business2 = new Business()
            {
                IndustryType = "27025",
                Territory = "001",
                Exposure = 2000,
                Address = Address2,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="BI",
                          Deductible=250,
                          OccuranceLimit=25000,
                          AggregateLimit=50000,
                          CoveragePremium=0d

                     }
                }

            };
            businesses.Add(business);
            businesses.Add(business2);

            Prospect Prospect1 = new Prospect()
            {
                OrganisationName = "Mahindra",
                Contact = "7674878760",
                Email = "vijay@gmail.com",
                NumberOfBusinessUnits = 2,
                Businesses = businesses
            };

            PolicyTerm PolicyTerm = new PolicyTerm()
            {
                PolicyEffectiveDate = System.DateTime.Now,
                PolicyExpiryDate = System.DateTime.Now.AddDays(5)
            };

            Quote quote = new Quote()
            {
                QuoteNumber = "Q-2302005",
                RiskState = "USA",
                Premium = 0d,
                AgentId = "A001",
                Prospect = Prospect1,
                PolicyTerm = PolicyTerm
            };
            return quote;

        }
    }
}
