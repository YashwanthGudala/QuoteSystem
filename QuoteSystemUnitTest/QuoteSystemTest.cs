//using QuoteSystemDataAccess;
//using QuoteSystemDataModel;
//using System;
//using System.Collections.Generic;
//using Xunit;

//namespace QuoteSystemUnitTest
//{

//    public class QuoteSystemTest
//    {

//        [Theory]
//        [InlineData("Q23CGL-0001")]
//        [InlineData("Q23CGL-0002")]
//        [InlineData("Q23CGL-0003")]
//        public void ViewQuotePassingTest(string QuoteNumber)
//        {
//            // arrange+act
//            Quote quote = QuoteDataAccess.ViewQuote(QuoteNumber);

//            // assert
//            Assert.Equal(QuoteNumber, quote.QuoteNumber);
//        }

//        [Theory]
//        [InlineData("Q23CGL-2902")]
//        [InlineData("Q23CGL-29")]
//        [InlineData("Q-290202")]
//        public void ViewQuoteFailingTest(string QuoteNumber)
//        {
//            // arrange+act
//            Quote quote = QuoteDataAccess.ViewQuote(QuoteNumber);

//            // assert
//            Assert.Null(quote);
//        }

//        [Fact]
//        public void ViewQuoteFailingTest2()
//        {
//            // arrange
//            string QuoteNumber = null;

//            // act+assert
//            Assert.Throws<DatabaseException>(() => QuoteDataAccess.ViewQuote(QuoteNumber));
//        }

//        [Fact]
//        public void ViewAllQuotePassingTest()
//        {
//            // arrange+act
//            List<Quote> Quotes = QuoteDataAccess.ViewAllQuote();

//            // assert
//            Assert.NotNull(Quotes);
//        }

//        [Fact]
//        public void AddQuotePassingTest()
//        {
//            // arrange+act
//            string Expected = "Successfully Added";
//            Address Address = new Address()
//            {
//                FirstLine = "basar",
//                SecondLine = "nirmal",
//                City = "nzd",
//                State = "telangana",
//                ZipCode = "505301",
//            };

//            List<Business> businesses = new List<Business>();
//            Business business = new Business()
//            {
//                IndustryType = "27025",
//                Territory = "002",
//                Exposure = 3000,
//                Address = Address,
//                Coverages = new List<Coverage>()
//                {
//                     new Coverage()
//                     {
//                          CoverageName = "BI",
//                          Deductible = 10000,
//                          OccuranceLimit = 25000,
//                          AggregateLimit = 50000,
//                          CoveragePremium = 0.0d,
//                     },
//                },
//            };
//            Address Address2 = new Address()
//            {
//                FirstLine = "nuzvid",
//                SecondLine = "idukulapaya",
//                City = "vizag",
//                State = "AP",
//                ZipCode = "503401",
//            };
//            Business business2 = new Business()
//            {
//                IndustryType = "27160",
//                Territory = "001",
//                Exposure = 1000,
//                Address = Address2,
//                Coverages = new List<Coverage>()
//                {
//                     new Coverage()
//                     {
//                          CoverageName="PD",
//                          Deductible=5000,
//                          OccuranceLimit=100000,
//                          AggregateLimit=200000,
//                          CoveragePremium=0.0d
//                     },
//                },
//            };
//            businesses.Add(business);
//            businesses.Add(business2);

//            Prospect Prospect1 = new Prospect()
//            {
//                OrganisationName = "IIITB",
//                Contact = "7674878760",
//                Email = "iiitb@gmail.com",
//                NumberOfBusinessUnits = 2,
//                Businesses = businesses,
//            };

//            PolicyTerm PolicyTerm = new PolicyTerm()
//            {
//                PolicyEffectiveDate = System.DateTime.Now,
//                PolicyExpiryDate = System.DateTime.Now.AddDays(5),
//            };

//            Quote quote = new Quote()
//            {
//                QuoteNumber = "",
//                RiskState = "AL",
//                Premium = 0.0d,
//                AgentId = "A001",
//                Prospect = Prospect1,
//                PolicyTerm = PolicyTerm,
//            };
//            string observed = QuoteDataAccess.AddQuote(quote);

//            // assert
//            Assert.Equal(observed, Expected);
//        }

//        [Fact]
//        public void AddQuoteFailingTest()
//        {
//            // arrange
//            Quote quote = null;
//            string Expected = "Unable to add Null Quote";

//            // act
//            string observed = QuoteDataAccess.AddQuote(quote);

//            // assert
//            Assert.Equal(Expected, observed);
//        }

//        [Fact]
//        public void AddQuoteFailingTest2()
//        {
//            // arrange
//            string Expected = "Quote Already Exists !!";
//            Address Address = new Address()
//            {
//                FirstLine = "basar",
//                SecondLine = "nirmal",
//                City = "nzd",
//                State = "telangana",
//                ZipCode = "505301",
//            };

//            List<Business> businesses = new List<Business>();
//            Business business = new Business()
//            {
//                IndustryType = "27025",
//                Territory = "002",
//                Exposure = 3000,
//                Address = Address,
//                Coverages = new List<Coverage>()
//                {
//                     new Coverage()
//                     {
//                          CoverageName="BI",
//                          Deductible=10000,
//                          OccuranceLimit=25000,
//                          AggregateLimit=50000,
//                          CoveragePremium=0.0d

//                     },
//                },
//            };
//            Address Address2 = new Address()
//            {
//                FirstLine = "nuzvid",
//                SecondLine = "idukulapaya",
//                City = "vizag",
//                State = "AP",
//                ZipCode = "503401",
//            };
//            Business business2 = new Business()
//            {
//                IndustryType = "27160",
//                Territory = "001",
//                Exposure = 1000,
//                Address = Address2,
//                Coverages = new List<Coverage>()
//                {
//                     new Coverage()
//                     {
//                          CoverageName="PD",
//                          Deductible=5000,
//                          OccuranceLimit=100000,
//                          AggregateLimit=200000,
//                          CoveragePremium=0.0d
//                     },
//                },
//            };
//            businesses.Add(business);
//            businesses.Add(business2);

//            Prospect Prospect1 = new Prospect()
//            {
//                OrganisationName = "IIITB",
//                Contact = "7674878760",
//                Email = "iiitb@gmail.com",
//                NumberOfBusinessUnits = 2,
//                Businesses = businesses,
//            };

//            PolicyTerm PolicyTerm = new PolicyTerm()
//            {
//                PolicyEffectiveDate = System.DateTime.Now,
//                PolicyExpiryDate = System.DateTime.Now.AddDays(5),
//            };

//            Quote quote = new Quote()
//            {
//                QuoteNumber = "Q23CGL-0001",
//                RiskState = "AL",
//                Premium = 0.0d,
//                AgentId = "A001",
//                Prospect = Prospect1,
//                PolicyTerm = PolicyTerm,
//            };

//            // act
//            string observed = QuoteDataAccess.AddQuote(quote);

//            // assert
//            Assert.Equal(Expected, observed);
//        }
//        [Fact]
//        public void UpdateQuotePassingTest()
//        {
//            // arrange
//            string Expected = "Successfully Updated";

//            Address Address = new Address()
//            {
//                FirstLine = "basar",
//                SecondLine = "nirmal",
//                City = "nzd",
//                State = "telangana",
//                ZipCode = "505301",
//            };

//            List<Business> businesses = new List<Business>();
//            Business business = new Business()
//            {
//                IndustryType = "27025",
//                Territory = "002",
//                Exposure = 3000,
//                Address = Address,
//                Coverages = new List<Coverage>()
//                {
//                     new Coverage()
//                     {
//                          CoverageName = "BI",
//                          Deductible = 10000,
//                          OccuranceLimit = 25000,
//                          AggregateLimit = 50000,
//                          CoveragePremium = 0.0d,
//                     },
//                },
//            };
//            Address Address2 = new Address()
//            {
//                FirstLine = "nuzvid",
//                SecondLine = "idukulapaya",
//                City = "vizag",
//                State = "AP",
//                ZipCode = "503401",
//            };
//            Business business2 = new Business()
//            {
//                IndustryType = "27035",
//                Territory = "001",
//                Exposure = 1000,
//                Address = Address2,
//                Coverages = new List<Coverage>()
//                {
//                     new Coverage()
//                     {
//                          CoverageName = "PD",
//                          Deductible = 5000,
//                          OccuranceLimit = 100000,
//                          AggregateLimit = 200000,
//                          CoveragePremium = 0.0d,
//                     },
//                },
//            };
//            businesses.Add(business);
//            businesses.Add(business2);

//            Prospect Prospect1 = new Prospect()
//            {
//                OrganisationName = "IIITB",
//                Contact = "7674878760",
//                Email = "iiitb@gmail.com",
//                NumberOfBusinessUnits = 2,
//                Businesses = businesses,
//            };

//            PolicyTerm PolicyTerm = new PolicyTerm()
//            {
//                PolicyEffectiveDate = System.DateTime.Now,
//                PolicyExpiryDate = System.DateTime.Now.AddDays(5),
//            };

//            Quote quote = new Quote()
//            {
//                QuoteNumber = "Q23CGL-0006",
//                RiskState = "Nacharam",
//                Premium = 0.0d,
//                AgentId = "A1000",
//                Prospect = Prospect1,
//                PolicyTerm = PolicyTerm,
//            };

//            // act
//            string observed = QuoteDataAccess.UpdateQuote(quote);

//            // assert
//            Assert.Equal(Expected, observed);
//        }

//        [Fact]
//        public void UpdateQuoteFailingTest()
//        {
//            // arrange
//            string Expected = "Unable to Update a null quote";
//            Quote quote = null;

//            // act
//            string observed = QuoteDataAccess.UpdateQuote(quote);

//            // assert
//            Assert.Equal(Expected, observed);
//        }

//        [Fact]
//        public void UpdateQuoteFailingTest2()
//        {
//            // arrange
//            string Expected = "Quote Not Found";
//            Address Address = new Address()
//            {
//                FirstLine = "basar",
//                SecondLine = "nirmal",
//                City = "nzd",
//                State = "telangana",
//                ZipCode = "505301",
//            };

//            List<Business> businesses = new List<Business>();
//            Business business = new Business()
//            {
//                IndustryType = "27025",
//                Territory = "002",
//                Exposure = 3000,
//                Address = Address,
//                Coverages = new List<Coverage>()
//                {
//                     new Coverage()
//                     {
//                          CoverageName = "BI",
//                          Deductible = 10000,
//                          OccuranceLimit = 25000,
//                          AggregateLimit = 50000,
//                          CoveragePremium = 0.0d,
//                     },
//                },

//            };
//            Address Address2 = new Address()
//            {
//                FirstLine = "nuzvid",
//                SecondLine = "idukulapaya",
//                City = "vizag",
//                State = "AP",
//                ZipCode = "503401",
//            };
//            Business business2 = new Business()
//            {
//                IndustryType = "27035",
//                Territory = "001",
//                Exposure = 1000,
//                Address = Address2,
//                Coverages = new List<Coverage>()
//                {
//                     new Coverage()
//                     {
//                          CoverageName = "PD",
//                          Deductible = 5000,
//                          OccuranceLimit = 100000,
//                          AggregateLimit = 200000,
//                          CoveragePremium = 0.0d,
//                     },
//                },
//            };

//            businesses.Add(business);
//            businesses.Add(business2);

//            Prospect Prospect1 = new Prospect()
//            {
//                OrganisationName = "IIITB",
//                Contact = "7674878760",
//                Email = "iiitb@gmail.com",
//                NumberOfBusinessUnits = 2,
//                Businesses = businesses,
//            };

//            PolicyTerm PolicyTerm = new PolicyTerm()
//            {
//                PolicyEffectiveDate = System.DateTime.Now,
//                PolicyExpiryDate = System.DateTime.Now.AddDays(5),
//            };

//            Quote quote = new Quote()
//            {
//                QuoteNumber = "Q23CGL-290",
//                RiskState = "Nacharam",
//                Premium = 0.0d,
//                AgentId = "A1000",
//                Prospect = Prospect1,
//                PolicyTerm = PolicyTerm,
//            };

//            // act
//            string observed = QuoteDataAccess.UpdateQuote(quote);

//            // assert
//            Assert.Equal(Expected, observed);
//        }

//        [Fact]
//        public void UpdateQuoteFailingTest3()
//        {
//            // arrange
//            string Expected = "Prospect Details Not Found";

//            PolicyTerm PolicyTerm = new PolicyTerm()
//            {
//                PolicyEffectiveDate = System.DateTime.Now,
//                PolicyExpiryDate = System.DateTime.Now.AddDays(5),
//            };

//            Quote quote = new Quote()
//            {
//                QuoteNumber = "Q23CGL-0007",
//                RiskState = "Nacharam",
//                Premium = 0.0d,
//                AgentId = "A1000",
//                Prospect = null,
//                PolicyTerm = PolicyTerm,
//            };

//            // act
//            string observed = QuoteDataAccess.UpdateQuote(quote);

//            // assert
//            Assert.Equal(Expected, observed);
//        }

//        [Theory]
//        [InlineData("Q23CGL-0005")]
//        public void DeleteQuotePassingTest(string QuoteNumber)
//        {
//            // arrange
//            string Expected = "Successfully Deleted";

//            // act
//            string Observed = QuoteDataAccess.DeleteQuote(QuoteNumber);

//            // assert
//            Assert.Equal(Expected, Observed);
//        }

//        [Fact]
//        public void DeleteQuoteFailingTest()
//        {
//            // arrange
//            string Expected = "Quote Number is Mandatory";
//            string QuoteNumber = null;

//            // act
//            string Observed = QuoteDataAccess.DeleteQuote(QuoteNumber);

//            // assert
//            Assert.Equal(Expected, Observed);
//        }

//        [Theory]
//        [InlineData("Q-290")]
//        [InlineData("Q-291")]
//        [InlineData("Q-292")]
//        public void DeleteQuoteFailingTest2(string QuoteNumber)
//        {
//            // arrange
//            string Expected = "Quote Not Found";

//            // act
//            string Observed = QuoteDataAccess.DeleteQuote(QuoteNumber);

//            // assert
//            Assert.Equal(Expected, Observed);
//        }




//    }
//}
