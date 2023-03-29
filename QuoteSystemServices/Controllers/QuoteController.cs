using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuoteSystemDataAccess;
using QuoteSystemDataModel;
namespace QuoteSystemServices.Controllers
{
    public class QuoteController : ApiController
    {
        [HttpGet]
        [Route("api/Quote/ViewQuote")]
        public string ViewQuote(string QuoteNumber)
        {
            Quote quote = QuoteDataAccess.ViewQuote(QuoteNumber);

            return quote.RiskState;
            
        }
    }
}
