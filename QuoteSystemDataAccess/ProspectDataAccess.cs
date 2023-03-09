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
            using (var dbContext = new QuoteDataModelContainer())
            {
                 prospect = dbContext.Prospects.Where(c => c.Id == prospectid).FirstOrDefault();
            }

            return prospect;

        }

        public static List<Prospect> ViewAllProspects()
        {
            List<Prospect> prospects;
            using (var dbContext = new QuoteDataModelContainer())
            {
                prospects = dbContext.Prospects.ToList();
            }

            return prospects;
        }
    }
}
