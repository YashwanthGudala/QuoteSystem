using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Configuration;

namespace QuoteSystemAPIServices.Filters
{
    public class QuoteServicesFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string log = string.Format("Action Method {0}, is executing at {1} ", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToString());
            string FilePath = ConfigurationManager.AppSettings["FilterLogsFilePath"];

            File.AppendAllText(FilePath, "Quote Service Logs : " + log + Environment.NewLine);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string log = string.Format("Action Method {0}, is executed at {1} ", actionExecutedContext.ActionContext.ActionDescriptor.ActionName, DateTime.Now.ToString());
            string FilePath = ConfigurationManager.AppSettings["FilterLogsFilePath"];

            File.AppendAllText(FilePath, "Quote Service Logs : " + log + Environment.NewLine);

        }
    }
}