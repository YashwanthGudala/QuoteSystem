using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;
namespace QuoteSystemDataAccessTest
{
    public class TestBusinessDataAccess
    {
        public static void AddBusinessTest()
        {
            List<Business> businesses = new List<Business>();

            Address Address = new Address()
            {
                FirstLine = "Raghavendra Nagar",
                SecondLine = "Nacharam",
                City = "Hyd",
                State = "TS",
                ZipCode = "508901",
            };

            Business business = new Business()
            {
                IndustryType = "Dairy Form",
                Territory = "005",
                Exposure = 1000,
                Address = Address,
                Coverages = new List<Coverage>()
                {
                    new Coverage()
                    {
                        CoverageName = "Advertising",
                        Deductible = 300,
                        OccuranceLimit = 50000,
                        AggregateLimit = 100000,
                        CoveragePremium = 500.0d

                    },
                    new Coverage()
                    {
                        CoverageName = "Product",
                        Deductible = 300,
                        OccuranceLimit = 50000,
                        AggregateLimit = 100000,
                        CoveragePremium = 500.0d

                    }
                }
            };

            Address Address2 = new Address()
            {
                FirstLine = "NGRI",
                SecondLine = "Hyd",
                City = "Hyd",
                State = "TS",
                ZipCode = "505301",
            };
            Business business2 = new Business()
            {
                IndustryType = "Wholesale Shop",
                Territory = "003",
                Exposure = 3000,
                Address = Address2,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Advertising",
                          Deductible=350,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d

                     } ,
                     new Coverage()
                     {
                          CoverageName="Product",
                          Deductible=250,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d
                     }
                }

            };

            businesses.Add(business);
            businesses.Add(business2);

            string status = BusinessDataAccess.AddBusiness("Mahindra", businesses);
            Console.WriteLine(status);
        }

        public static void RemoveBusinessTest()
        {
            string status = BusinessDataAccess.RemoveBusiness("Mahindra", 48);
            Console.WriteLine(status);
        }

        public static void UpdateBusinessTest()
        {
           

            Address Address2 = new Address()
            {
                FirstLine = "uppal",
                SecondLine = "Hyd",
                City = "Hyd",
                State = "TS",
                ZipCode = "505301",
            };
            Business business2 = new Business()
            {
                IndustryType = "manufacturing",
                Id = 49,
                Territory = "008",
                Exposure = 3000,
                Address = Address2,
                Coverages = new List<Coverage>()
                {
                     new Coverage()
                     {
                          CoverageName="Fire A",
                          Deductible=350,
                          OccuranceLimit=12344,
                          AggregateLimit=56789,
                          CoveragePremium=502.0d

                     } ,
                     new Coverage()
                     {
                          CoverageName="medical expenses",
                          Deductible=250,
                          OccuranceLimit=50000,
                          AggregateLimit=100000,
                          CoveragePremium=500.0d
                     }
                }

            };

            
            

            string status = BusinessDataAccess.UpdateBusiness("Mahindra", business2);
            Console.WriteLine(status);
        }

        public static void ViewAllBusinessTest()
        {
            List<Business> businesses = BusinessDataAccess.ViewAllBusiness("Mahindra");
            if(businesses.Count() == 0)
            {
                Console.WriteLine("Businessess Not Found");
            }
            foreach (var business in businesses)
            {
                Console.WriteLine(business.IndustryType);
            }
        }

        public static void ViewBusinessTest()
        {
            Business business = BusinessDataAccess.ViewBusiness("Mahindra", 49);
            if(business == null)
            {
                Console.WriteLine("Business Not Found");

            }
            else
            {
                Console.WriteLine(business.IndustryType);
            }
            
        }
    }
}
