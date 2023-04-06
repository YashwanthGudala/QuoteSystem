using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;
using log4net;

namespace QuoteSystemBusiness
{
    public class RatingEngine
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string BaserateTable = "Premises Operations Loss Cost";
        private static string LimitFactorTable = "Limit Factor";
        private static string DeductibleFactorTable = "Deductible Factor";

        public static RateMetaData metaData;
        public static void LoadMetaData()
        {
            try
            {
                string FilePath = ConfigurationManager.AppSettings["RateMetadataFilePath"];
                RateMetaData objectToDeserialize = new RateMetaData();
                XmlSerializer xmlserializer = new XmlSerializer(objectToDeserialize.GetType());

                using (StreamReader streamReader = new StreamReader(FilePath))
                {
                    metaData = (RateMetaData)xmlserializer.Deserialize(streamReader);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable To Fetch Data From XML File");
            }

            log.Info("Fetched Metadata From XML File");
        }

        public static float LookupRate(string TableName, params string[] inputratekeys)
        {
            if(TableName.Length == 0)
            {
                throw new DatabaseException("Proper Table Name is Required");
            }
            if(inputratekeys.Length == 0)
            {
                throw new DatabaseException("Proper Number of Rate Keys are Required");
            }
            LoadMetaData();
            float result = 0.0f;


            try
            {
                var ratetable = metaData.RateTables.RateTable.Where(c => c.Name == TableName).FirstOrDefault();

                if(ratetable is null)
                {
                    throw new DatabaseException("Rate Table Not Found");
                }

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
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable To Fetch From XML File");
            }


            log.Info("Fetch Rate Factor From Rate table : " + TableName);
            return result;



        }


        public static string RateQuote(Quote quote)
        {
            if(quote is null)
            {
                return "Quote Object Cannot be Null";
            }
            float TotalPremium = 0f;

            try
            {
                if(quote?.Prospect is null )
                {
                    return "Prospect Details Not Found";
                }
                foreach (var business in quote.Prospect.Businesses.ToList())
                {
                    float BusinessPremium = 0f;
                    float ExposureUnits = business.Exposure / 1000;

                    Coverage coverage = business.Coverages.FirstOrDefault();


                    //Baserate 
                    try
                    {
                        float BusinessBaserate = LookupRate(BaserateTable, business.IndustryType, business.Territory);

                        float LimitFactor = LookupRate(LimitFactorTable, coverage.OccuranceLimit.ToString(), coverage.AggregateLimit.ToString());

                        float DeductibleFactor = LookupRate(DeductibleFactorTable, coverage.Deductible.ToString(), coverage.CoverageName);


                        float AdjustLimitFactor = LimitFactor - DeductibleFactor;

                        BusinessPremium = BusinessBaserate * AdjustLimitFactor * ExposureUnits;

                        TotalPremium += BusinessPremium;
                    }
                    catch (Exception)
                    {

                        throw new DatabaseException("Unable To Calculate Premium , Issue with XML File ");
                    }

                    coverage.CoveragePremium = Math.Round(BusinessPremium,2);


                    

                }
                quote.Premium = Math.Round(TotalPremium,2);
                string response = QuoteDataAccess.UpdateQuote(quote);

                if(response != "Successfully Updated")
                {
                    return "Quote Details Not Found In Database , Please Pass Valid Quote Details";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Something Went Wrong");
            }

            log.Info("Calculated Premium For Quote Number : " + quote.QuoteNumber);
            return "Successfully Calculated Premium";

        }

      

    }
}
