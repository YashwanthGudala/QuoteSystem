using QuoteSystemDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuoteSystemDataAccess;
using QuoteSystemAPIServices.Filters;

namespace QuoteSystemAPIServices.Controllers
{
    [MetadataServicesFilter]
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

        [HttpGet]
        [Route("api/MetadataServices/GetAllCodeValueLists")]
        public List<CodeValueList> GetAllCodeValueLists()
        {
            List<CodeValueList> codeValueLists = MetadataDataAccess.GetAllCodeValueLists();

            return codeValueLists;
        }




        [HttpPost]
        [Route("api/MetadataServices/AddCodeValueLists")]
        public string GetValueFromCode(List<CodeValueList> codeValueLists)
        {
            string response = MetadataDataAccess.AddCodeValueLists(codeValueLists);

            return response;
        }
    }
}
