using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;

namespace QuoteSystemAPIServices.Controllers
{
    
    public class QuoteServiceController : ApiController
    {
        [HttpGet]
        [Route("api/QuoteServices/ViewQuote")]
        public Quote ViewQuote(string QuoteNumber)
        {
            Quote quote = QuoteDataAccess.ViewQuote(QuoteNumber);

            return quote;

        }

        [HttpGet]
        [Route("api/QuoteServices/ViewAllQuotes")]
        public List<Quote> ViewAllQuotes()
        {
            return QuoteDataAccess.ViewAllQuote();
        }

        [HttpGet]
        [Route("api/QuoteServices/DeleteQuote")]
        public string DeleteQuote(string QuoteNumber)
        {
            string response = QuoteDataAccess.DeleteQuote(QuoteNumber);
            return response;
        }

        [HttpPost]
        [Route("api/QuoteServices/AddQuote")]
        public string AddQuote(Quote quote)
        {
            string response = QuoteDataAccess.AddQuote(quote);
            return response;
        }

        [HttpPost]
        [Route("api/QuoteServices/UpdateQuote")]
        public string UpdateQuote(Quote quote)
        {
            string response = QuoteDataAccess.UpdateQuote(quote);
            return response;
        }

    }
}
