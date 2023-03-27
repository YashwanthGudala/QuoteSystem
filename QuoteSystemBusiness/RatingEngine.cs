using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuoteSystemBusiness
{
    public class RatingEngine
    {
        public static RateMetaData metaData;
        public static void LoadMetaData()
        {
            string FilePath = "D:\\RateMetaData.xml";
            RateMetaData objectToDeserialize = new RateMetaData();
            XmlSerializer xmlserializer = new XmlSerializer(objectToDeserialize.GetType());

            using (StreamReader streamReader = new StreamReader(FilePath))
            {
                metaData = (RateMetaData)xmlserializer.Deserialize(streamReader);
            }


        }
        public static void DisplayAllTables()
        {
            LoadMetaData();

            foreach (var ratetable in metaData.RateTables.RateTable.ToList())
            {
                //name
                Console.WriteLine(ratetable.Name);

                //rate rows
                foreach (var raterow in ratetable.RateRow.ToList())
                {
                    //rate keys
                    foreach (var ratekey in raterow.RateKeys.RateKey.ToList())
                    {
                        Console.WriteLine(ratekey.KeyName + "--->" + ratekey.KeyValue);
                    }

                    //rate value
                    Console.WriteLine(raterow.RateFactor.FactorName + "--->" + raterow.RateFactor.FactorValue);
                }
            }

        }

        public static float LookupRate(string TableName, params string[] inputratekeys)
        {
            LoadMetaData();
            float result = 0.0f;

            
                var ratetable = metaData.RateTables.RateTable.Where(c => c.Name == TableName).FirstOrDefault();

                //rate rows
                foreach (var raterow in ratetable.RateRow.ToList())
                {
                    bool flag = true;
                    //rate keys
                    for (int i = 0; i < raterow.RateKeys.RateKey.Count(); i++)
                    {
                        if (raterow.RateKeys.RateKey.ElementAt(i).KeyValue != inputratekeys.ElementAt(i))
                        {
                            flag = false;
                        }

                    }

                    if (flag == true)
                    {
                        result = (float)raterow.RateFactor.FactorValue;
                    }

                }

            

            return result;



        }

        public static void GetPremiumTest()
        {
            int exposureunits = 2;

            string classcode = "27025";
            string teritorry = "001";

            float baserate = LookupRate("Premises Operations Loss Cost", classcode, teritorry);

            float limitfactor = LookupRate("Limit Factor", "25000", "50000");

            float DeductibleFactor = LookupRate("Deductible Factor", "250", "BI");

            float adjlimitfactor = limitfactor - DeductibleFactor;
            float premium = baserate * adjlimitfactor * exposureunits;

            Console.WriteLine(premium);

        }
        
    }
}
