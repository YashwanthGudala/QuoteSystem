using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataAccess;
using QuoteSystemDataModel;

namespace QuoteSystemDataAccessTest
{
    public class TestAgentDataAccess
    {
        public static void AddAgentTest()
        {
            Agent agent = new Agent()
            {
                AgencyName = "ABC",
                AgentId = "001",
                AgentName = "Yash",
                Contact = "7674878760",
                Mail = "yash@gmail.com",
                Password = "yash123"

            };

            string response = AgentDataAccess.AddAgent(agent);

            Console.WriteLine(response);
        }
        public static void VerifyAgentTest()
        {
            string Email = "yash@gmail.com";
            string Password = "yash123";
            string result = AgentDataAccess.VerifyAgentLogin(Email, Password);
            Console.WriteLine(result);
        }
    }
}
