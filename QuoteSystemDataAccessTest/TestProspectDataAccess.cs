using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;

namespace QuoteSystemDataAccessTest
{
    class TestProspectDataAccess
    {
        public static void ViewProspectTest()
        {
            int id = 1;

            Prospect prospect = QuoteSystemDataAccess.ProspectDataAccess.ViewProspect(id);

            Console.WriteLine(prospect.OrganisationName);
        }

        public static void ViewAllProspectsTest()
        {
            List<Prospect> prospects = QuoteSystemDataAccess.ProspectDataAccess.ViewAllProspects();

            foreach (var prospect in prospects)
            {
                Console.WriteLine(prospect.OrganisationName);
            }
        }
    }
}
