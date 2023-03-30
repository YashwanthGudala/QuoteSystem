using QuoteSystemDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuoteSystemDataAccess;
namespace QuoteSystemAPIServices.Controllers
{
    public class MetadataServiceController : ApiController
    {
        [HttpGet]
        [Route("api/MetadataServices/GetCodeValuesByListName")]
        public List<CodeValue> GetCodeValuesByListName(string ListName)
        {
            var CodeValues = MetadataDataAccess.GetCodeValuesByListName(ListName);

            return CodeValues;
            

        }

        [HttpGet]
        [Route("api/MetadataServices/GetValueFromCode")]
        public string GetValueFromCode(String ListName, string Key)
        {
            string response = MetadataDataAccess.GetValueFromCode(ListName, Key);

            return response;
        }
    }
}
