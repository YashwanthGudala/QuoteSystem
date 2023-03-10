using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;

namespace QuoteSystemDataAccess
{
    public class ProspectDataAccess
    {
        public static Prospect ViewProspect(int prospectid)
        {
            Prospect prospect;
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    prospect = dbContext.Prospects.Where(c => c.Id == prospectid).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw new DatabaseException("Unable To Fetch Prospect Details From Database");
            }

            return prospect;

        }

        public static List<Prospect> ViewAllProspects()
        {
            List<Prospect> prospects;
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    prospects = dbContext.Prospects.ToList();
                }
            }
            catch (Exception)
            {

                throw new DatabaseException("Unable To Fetch Prospect Records From Database");
            }

            return prospects;
        }
    }
}
