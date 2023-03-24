using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuoteSystemBusiness
{
    public class RatingEngine
    {
        public static void LoadMetaData()
        {
            string filepath = "D:\\RateMetaData.xml";

            RateMetaData objectToDeserialize = new RateMetaData();
            XmlSerializer xmlserializer = new XmlSerializer(objectToDeserialize.GetType());
            RateMetaData result;
            

            using (StreamReader streamReader = new StreamReader(filepath))
            {
                result = (RateMetaData)xmlserializer.Deserialize(streamReader);
            }

            Console.WriteLine(result.RateTables.FirstOrDefault().Name);


        }
    }
}
