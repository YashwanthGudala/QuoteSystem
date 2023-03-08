using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;

namespace QuoteSystemDataAccessTest
{
    class QuoteDataAccessTest
    {
        static void Main(string[] args)
        {
            //Testing add quote
            AddQuoteTest();
            Console.ReadKey();


        }

        public static Quote GetSampleQuote()
        {
            Address Address = new Address()
            {
                FirstLine = "Toopran",
                SecondLine = "ECIL",
                City = "Hyd",
                State = "telangana",
                ZipCode = "505301",
            };

            List<Business> businesses = new List<Business>();


            Business business = new Business()
            {
                IndustryType = "Hardware",
                Territory = "001",
                Exposure = 1000,
                Address = Address,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Theft",
                          Deductible=10000,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     }
                }

            };
            businesses.Add(business);

            Prospect Prospect1 = new Prospect()
            {
                OrganisationName = "Jarus",
                Contact = "6301736456",
                Email = "vijay@gmail.com",
                NumberOfBusinessUnits = 4,
                Businesses = businesses
            };

            PolicyTerm PolicyTerm = new PolicyTerm()
            {
                PolicyEffectiveDate = System.DateTime.Now,
                PolicyExpiryDate = System.DateTime.Now.AddDays(5)
            };

            Quote quote = new Quote()
            {
                QuoteNumber = "Q-12345",
                RiskState = "India",
                Premium = 100.0d,
                AgentId = "A123",
                Prospect = Prospect1,
                PolicyTerm = PolicyTerm
            };
            return quote;

        }

        public static void AddQuoteTest()
        {
            Quote quote = GetSampleQuote();

            QuoteSystemDataAccess.QuoteDataAccess.AddQuote(quote);
        }
    }
}
