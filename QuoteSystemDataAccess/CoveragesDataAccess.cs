using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;

namespace QuoteSystemDataAccess
{
    public class CoveragesDataAccess
    {
        public static string AddCoverages(int BusinessId, List<Coverage> coverages)
        {
            if (coverages == null)
            {
                return "Unable To Handle Null Coverage";
            }
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {


                    Business business = dbContext.Businesses.Where(c => c.Id == BusinessId).FirstOrDefault();
                    if (business == null)
                    {
                        return "Business Not Found!!";
                    }
                    foreach (var coverage in coverages)
                    {
                        business.Coverages.Add(coverage);

                    }


                    dbContext.SaveChanges();

                    return "Successfully Added";


                }
            }
            catch (Exception)
            {

                throw new DatabaseException("Unable To Add Coverage , Something Went Wrong");
            }

        }
        public static string UpdateCoverage(int BusinessId, string CoverageName, Coverage UpdatedCoverage)
        {
            if (CoverageName.Length == 0)
            {
                return "Coverage Name is Required";
            }
            if (UpdatedCoverage == null)
            {
                return "Can't Handle Null Coverage";
            }

            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {

                    Business business = dbContext.Businesses.Where(c => c.Id == BusinessId).FirstOrDefault();
                    if (business == null)
                    {
                        return "Business Not Found!!";
                    }

                    Coverage OldCoverage = dbContext.Coverages.Where(c => c.BusinessId == BusinessId && c.CoverageName == CoverageName).FirstOrDefault();
                    if (OldCoverage == null)
                    {
                        return "Coverage Not Found";
                    }

                    OldCoverage.AggregateLimit = UpdatedCoverage.AggregateLimit;
                    OldCoverage.Deductible = UpdatedCoverage.Deductible;
                    OldCoverage.OccuranceLimit = UpdatedCoverage.OccuranceLimit;
                    OldCoverage.CoveragePremium = UpdatedCoverage.CoveragePremium;

                    dbContext.SaveChanges();
                    return "Successfully Updated";
                }
            }
            catch (Exception)
            {

                throw new DatabaseException("Unable To Update Coverage , Something Went Wrong");
            }
        }
        public static string DeleteCoverage(int BusinessID, string CoverageName)
        {
            if (CoverageName.Length == 0)
            {
                return "Coverage name is mandatory";
            }

            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    Business business = dbContext.Businesses.Where(c => c.Id == BusinessID).FirstOrDefault();

                    if (business == null)
                    {
                        return "business doest not exists";
                    }
                    Coverage coverage = business.Coverages.Where(c => c.CoverageName == CoverageName).FirstOrDefault();

                    if (coverage == null)
                    {
                        return "Coverage doest not exists";
                    }
                    dbContext.Coverages.Remove(coverage);

                    dbContext.SaveChanges();
                }
            }

            catch (Exception)
            {
                throw new DatabaseException("Unable to Delete Coverage");
            }

            return "Coverage Deleted successfully";
        }

        public static List<Coverage> GetAllCoverages(int BusinessID)
        {
            List<Coverage> coverages = new List<Coverage>();

            using (var dbContext = new QuoteDataModelContainer())
            {
                Business business = dbContext.Businesses.Where(c => c.Id == BusinessID).FirstOrDefault();
                foreach (var coverage in business.Coverages.ToList())
                {
                    coverages.Add(coverage);
                }
                return coverages;
            }
        }
        public static Coverage ViewSpecificCoverage(int BusinessID, string CoverageName)
        {


            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    Business business = dbContext.Businesses.Where(c => c.Id == BusinessID).FirstOrDefault();

                    if (business == null)
                    {
                        return null;
                    }
                    Coverage coverage = business.Coverages.Where(c => c.CoverageName == CoverageName).FirstOrDefault();

                    return coverage;
                }
            }

            catch (Exception)
            {
                throw new DatabaseException("Unable to view Coverage");
            }

        }
    }
}
