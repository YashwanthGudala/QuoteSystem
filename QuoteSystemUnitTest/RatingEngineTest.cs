using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemBusiness;
using QuoteSystemDataModel;
using Xunit;

namespace QuoteSystemUnitTest
{
    public class RatingEngineTest
    {
        //[Fact]
        //public void RateQuoteFailingTest()
        //{
        //    Quote quote = null;

        //    string ExpectedOutput = "Quote Object Cannot be Null";

        //    string ObservedOutput = RatingEngine.RateQuote(quote);

        //    Assert.Equal(ExpectedOutput, ObservedOutput);
        //}

        [Fact]
        public void RateQuotePassingTest()
        {
            //Arrange
            
           
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
            Quote quote = QuoteSystemDataAccess.QuoteDataAccess.ViewQuote("Q23CGL-0003");

            string ExpectedOutput = "Successfully Calculated Premium";
            //Act
            string ObservedOutput = RatingEngine.RateQuote(quote);

            //Assert

            Assert.Equal(ExpectedOutput, ObservedOutput);


        }
    }
}
