using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;

namespace QuoteSystemDataAccess
{
    class AgentDataAccess
    {
        public static void AddAgent(Agent agent)
        {
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    dbContext.Agents.Add(agent);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
