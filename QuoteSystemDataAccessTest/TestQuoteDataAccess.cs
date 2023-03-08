using System;
using System.Collections.Generic;

using QuoteSystemDataAccess;
using QuoteSystemDataModel;
namespace QuoteSystemDataAccessTest
{
    class TestQuoteDataAccess
    {
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
                Territory = "002",
                Exposure = 2000,
                Address = Address,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Fire",
                          Deductible=10000,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

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
                IndustryType = "Software",
                Territory = "002",
                Exposure = 2000,
                Address = Address2,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Product",
                          Deductible=10000,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     }
                }

            };
            businesses.Add(business);
            businesses.Add(business2);

            Prospect Prospect1 = new Prospect()
            {
                OrganisationName = "Tata",
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
                QuoteNumber = "Q-567",
                RiskState = "India",
                Premium = 100.0d,
                AgentId = "A124",
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

        public static void RemoveQuoteTest()
        {
            QuoteSystemDataAccess.QuoteDataAccess.DeleteQuote("Q-567");
        }
    }
}
