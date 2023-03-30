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
                FirstLine = "Cosmos Bank",
                SecondLine = "ECIL",
                City = "Hyd",
                State = "telangana",
                ZipCode = "505301",
            };

            List<Business> businesses = new List<Business>();


            Business business = new Business()
            {
                IndustryType = "AutoMobiles",
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
                IndustryType = "IT",
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
                QuoteNumber = "Q-2302001",
                RiskState = "USA",
                Premium = 500.0d,
                AgentId = "A001",
                Prospect = Prospect1,
                PolicyTerm = PolicyTerm
            };
            return quote;

        }
        public static Quote GetSampleUpdateQuote()
        {
            Address Address = new Address()
            {
                FirstLine = "Raghavendra Nagar",
                SecondLine = "Nacharam",
                City = "Hyd",
                State = "TS",
                ZipCode = "508901",
            };

            List<Business> businesses = new List<Business>();


            Business business = new Business()
            {
                IndustryType = "Dairy Form",
                Territory = "001",
                Exposure = 1000,
                Address = Address,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Advertising",
                          Deductible=300,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     } ,
                     new Coverage()
                     {
                          CoverageName="Product",
                          Deductible=300,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     }
                }

            };
            Address Address2 = new Address()
            {
                FirstLine = "NGRI",
                SecondLine = "Hyd",
                City = "Hyd",
                State = "TS",
                ZipCode = "505301",
            };
            Business business2 = new Business()
            {
                IndustryType = "Wholesale Shop",
                Territory = "003",
                Exposure = 3000,
                Address = Address2,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Advertising",
                          Deductible=350,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     } ,
                     new Coverage()
                     {
                          CoverageName="Product",
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
                OrganisationName = "Nani Group",
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
                QuoteNumber = "Q-2302001",
                RiskState = "France",
                Premium = 600.0d,
                AgentId = "A001",
                Prospect = Prospect1,
                PolicyTerm = PolicyTerm
            };
            return quote;

        }
        public static Quote GetSampleRatingQuote()
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
                OrganisationName = "Adani Group",
                Contact = "7674878760",
                Email = "vijay@gmail.com",
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
                QuoteNumber = "",
                RiskState = "Kansas",
                Premium = 0d,
                AgentId = "A002",
                Prospect = Prospect1,
                PolicyTerm = PolicyTerm
            };
            return quote;

        }

        public static void AddQuoteTest()
        {
            try
            {
                Quote quote = GetSampleRatingQuote();

                string res = QuoteSystemDataAccess.QuoteDataAccess.AddQuote(quote);

                Console.WriteLine(res);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static void RemoveQuoteTest()
        {
            string res = QuoteSystemDataAccess.QuoteDataAccess.DeleteQuote("Q23CGL0002");

            Console.WriteLine(res);
        }
        public static void UpdateQuoteTest()
        {
            Quote quote = GetSampleUpdateQuote();

            string res = QuoteSystemDataAccess.QuoteDataAccess.UpdateQuote(quote);

            Console.WriteLine(res);



        }
        public static void ViewQuoteTest()
        {
            Quote quote = QuoteSystemDataAccess.QuoteDataAccess.ViewQuote("Q-567");
            if (quote == null)
            {
                Console.WriteLine("Quote Not Found");
            }
            else
            {
                Console.WriteLine(quote.Premium + " " + quote.QuoteNumber + " " + quote.RiskState + " " + quote.AgentId + " " + quote.Prospect.OrganisationName);

            }


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
