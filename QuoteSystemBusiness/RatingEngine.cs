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

            foreach(var ratetable in metaData.RateTables.RateTable.ToList())
            {
                //name
                Console.WriteLine(ratetable.Name);

                //rate rows
                foreach(var raterow in ratetable.RateRow.ToList())
                {
                    //rate keys
                    foreach(var ratekey in raterow.RateKeys.RateKey.ToList())
                    {
                        Console.WriteLine(ratekey.KeyName + "--->" + ratekey.KeyValue);
                    }

                    //rate value
                    Console.WriteLine(raterow.RateFactor.FactorName + "--->" + raterow.RateFactor.FactorValue);
                }
            }

        }


    }
}
