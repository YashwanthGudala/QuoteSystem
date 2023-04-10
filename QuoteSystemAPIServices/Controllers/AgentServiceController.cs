using QuoteSystemAPIServices.Filters;
using QuoteSystemDataAccess;
using QuoteSystemDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteSystemAPIServices.Controllers
{
    [AgentServicesFilter]
    public class AgentServiceController : ApiController
    {
        [HttpPost]
        [Route("api/AgentServices/AddAgent")]
        public string AddAgent(Agent agent)
        {
            string result = AgentDataAccess.AddAgent(agent);
            return result;
        }

        [HttpGet]
        [Route("api/AgentServices/VerifyLogin")]
        public string VerifyAgent(string Email, string Password)
        {
            string result = AgentDataAccess.VerifyAgentLogin(Email, Password);
            return result;
        }
    }
}
