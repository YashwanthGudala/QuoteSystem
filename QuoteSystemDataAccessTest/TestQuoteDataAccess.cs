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
        public static Quote GetSampleUpdateQuote()
        {
            Address Address = new Address()
            {
                FirstLine = "Cosmos Bank",
                SecondLine = "Nacharam",
                City = "Hyd",
                State = "TS",
                ZipCode = "508901",
            };

            List<Business> businesses = new List<Business>();


            Business business = new Business()
            {
                IndustryType = "Bakery",
                Territory = "001",
                Exposure = 1000,
                Address = Address,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Fire",
                          Deductible=200,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     } ,
                     new Coverage()
                     {
                          CoverageName="Floods",
                          Deductible=300,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     }
                }

            };
            Address Address2 = new Address()
            {
                FirstLine = "Uppal",
                SecondLine = "Hyd",
                City = "Hyd",
                State = "TS",
                ZipCode = "505301",
            };
            Business business2 = new Business()
            {
                IndustryType = "Restaurant",
                Territory = "003",
                Exposure = 2000,
                Address = Address2,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Product",
                          Deductible=350,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     } ,
                     new Coverage()
                     {
                          CoverageName="Floods",
                          Deductible=250,
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
                OrganisationName = "Yash Group",
                Contact = "7674878760",
                Email = "yash@gmail.com",
                NumberOfBusinessUnits = 2,
                Businesses = businesses
            };

            PolicyTerm PolicyTerm = new PolicyTerm()
            {
                PolicyEffectiveDate = System.DateTime.Now,
                PolicyExpiryDate = System.DateTime.Now.AddDays(365)
            };

            Quote quote = new Quote()
            {
                QuoteNumber = "Q-12345",
                RiskState = "USA",
                Premium = 500.0d,
                AgentId = "A501",
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
        public static void UpdateQuoteTest()
        {
            Quote quote = GetSampleUpdateQuote();

            QuoteSystemDataAccess.QuoteDataAccess.UpdateQuote(quote);

            
            
        }
        public static void ViewQuoteTest()
        {
            Quote quote = QuoteSystemDataAccess.QuoteDataAccess.ViewQuote("Q-567");
            Console.WriteLine(quote.Premium + " " + quote.QuoteNumber + " " + quote.RiskState + " " + quote.AgentId + " " + quote.Prospect.OrganisationName);

        }
        public static void ViewAllQuoteTest()
        {
            List<Quote> Quotes = QuoteSystemDataAccess.QuoteDataAccess.ViewAllQuote();
            foreach (var quote in Quotes)
            {
                Console.WriteLine(quote.Premium + " " + quote.QuoteNumber + " " + quote.RiskState + " " + quote.AgentId + " " + quote.Prospect.OrganisationName);
            }
        }
    }
}
