﻿using QuoteSystemDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuoteSystemBusiness;

namespace QuoteSystemAPIServices.Controllers
{
    public class RateServiceController : ApiController
    {
        [HttpPost]
        [Route("api/RateServices/RateQuote")]
        public float RateQuote(Quote quote)
        {
            float response =  RatingEngine.RateQuote(quote);
            return response;


        }
    }
}
