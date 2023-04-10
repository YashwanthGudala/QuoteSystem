using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;

namespace QuoteSystemDataAccess
{
    public class AgentDataAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string AddAgent(Agent agent)
        {
            if (agent == null)
            {
                return "Agent Data is mandatory";
            }

            agent.Password = Base64Encode(agent.Password);
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    dbContext.Agents.Add(agent);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to Add Agent");
            }

            log.Info("Agent info saved successfully");
            return "Agent succesfully Added";
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string VerifyAgentLogin(string Email, string Password)
        {
            if (Email == null || Password == null)
            {
                return "these fields are mandatory";
            }

            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    foreach (var agent in dbContext.Agents)
                    {
                        if (agent.Mail == Email && Base64Decode(agent.Password) == Password)
                        {
                            log.Info("Login successfull");
                            return "Login successfull";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Login Failed");
            }

            log.Info("login failed");
            return "Login Failed";
        }
    
}
}
