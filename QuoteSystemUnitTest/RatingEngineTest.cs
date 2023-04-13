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
            Quote quote = QuoteSystemDataAccess.QuoteDataAccess.ViewQuote("Q23CGL-0001");

            string ExpectedOutput = "Successfully Calculated Premium";
            //Act
            string ObservedOutput = RatingEngine.RateQuote(quote);

            //Assert

            Assert.Equal(ExpectedOutput, ObservedOutput);


        }
    }
}
