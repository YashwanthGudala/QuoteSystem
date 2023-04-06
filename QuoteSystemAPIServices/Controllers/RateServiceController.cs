using QuoteSystemDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuoteSystemBusiness;
using QuoteSystemAPIServices.Filters;

namespace QuoteSystemAPIServices.Controllers
{
    [RateServicesFilter]
    public class RateServiceController : ApiController
    {
        [HttpPost]
        [Route("api/RateServices/RateQuote")]
        public string RateQuote(Quote quote)
        {
            string response =  RatingEngine.RateQuote(quote);
            return response;


        }
    }
}
