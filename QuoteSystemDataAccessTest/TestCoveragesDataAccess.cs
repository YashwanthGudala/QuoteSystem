using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;

namespace QuoteSystemDataAccessTest
{
    public class TestCoveragesDataAccess
    {
        public static void AddCoveragesTest()
        {
            List<Coverage> coverages = new List<Coverage>()
            {
                new Coverage()
            {
                CoverageName = "Product",
                CoveragePremium = 54d,
                AggregateLimit = 5000,
                Deductible = 250,
                OccuranceLimit = 1000
            } ,
                  new Coverage()
            {
                CoverageName = "Advertising",
                CoveragePremium = 54d,
                AggregateLimit = 7000,
                Deductible = 350,
                OccuranceLimit = 2000
            }



        };

            Console.WriteLine("Enter Business ID");
            int id = Convert.ToInt32(Console.ReadLine());

            string res = CoveragesDataAccess.AddCoverages(id, coverages);

            Console.WriteLine(res);

        }
        public static void UpdateCoverageTest()
        {
            Console.WriteLine("Enter Business ID");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Coverage Name");
            string CoverageName = Console.ReadLine();

            Coverage UpdatedCoverage = new Coverage()
            {
                CoverageName = "Product",
                CoveragePremium = 54d,
                AggregateLimit = 155000,
                Deductible = 550,
                OccuranceLimit = 2500
            };

            string res = CoveragesDataAccess.UpdateCoverage(id, CoverageName, UpdatedCoverage);

            Console.WriteLine(res);



        }
        public static void DeleteCoveragesTest()
        {
            Console.WriteLine("Enter business ID:");
            int BusinessID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Coverage name: ");
            string CoverageName = Console.ReadLine();
            string res = QuoteSystemDataAccess.CoveragesDataAccess.DeleteCoverage(BusinessID, CoverageName);
            Console.Write(res);
        }
        public static void GetAllCoveragesTest()
        {
            Console.WriteLine("Enter business ID:");
            int BusinessID = Convert.ToInt32(Console.ReadLine());
            List<Coverage> coverages = QuoteSystemDataAccess.CoveragesDataAccess.GetAllCoverages(BusinessID);

            if (coverages == null)
            {
                Console.WriteLine("No coverages Found");
            }
            else
            {
                foreach (var cover in coverages)
                {
                    Console.WriteLine("Coverage Name:" + cover.CoverageName + " Coverage Premium:" + cover.CoveragePremium + " Deductible:" + cover.Deductible);
                }

            }
        }
        public static void ViewSpecificCoveragesTest()
        {
            Console.WriteLine("Enter business ID:");
            int BusinessID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Coverage name: ");
            string CoverageName = Console.ReadLine();
            Coverage res = QuoteSystemDataAccess.CoveragesDataAccess.ViewSpecificCoverage(BusinessID, CoverageName);

            Console.WriteLine("Coverage Name:" + res.CoverageName + " Coverage Premium:" + res.CoveragePremium + " Deductible:" + res.Deductible);


        }


    }
}
