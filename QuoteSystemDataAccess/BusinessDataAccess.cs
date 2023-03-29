namespace QuoteSystemDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using QuoteSystemDataModel;

    public class BusinessDataAccess
    {
        public static string AddBusiness(string OrganisationName, List<Business> businesses)
        {
            if (OrganisationName == "")
            {
                return "Organisation Name is mandatory";
            }

            if (businesses == null)
            {
                return "Business field is mandatory";
            }

            Prospect prospect;
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    prospect = dbContext.Prospects.Where(p => p.OrganisationName == OrganisationName).FirstOrDefault();
                    if (prospect == null)
                    {
                        return "Unable to Find the prospect";
                    }

                    foreach (var business in businesses)
                    {
                        prospect.Businesses.Add(business);
                    }

                    prospect.NumberOfBusinessUnits += businesses.Count();
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new DatabaseException("Unable to add Businesses");
            }

            return "Succesfully added the business";
        }

        public static string RemoveBusiness(string OrganisationName, int BusinessId)
        {
            if (OrganisationName == "")
            {
                return "Organisation Name is mandatory";
            }

            Prospect prospect;
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    prospect = dbContext.Prospects
                                .Include("Businesses")
                                .Include("Businesses.Address")
                                .Include("Businesses.Coverages")
                                .Where(p => p.OrganisationName == OrganisationName).FirstOrDefault();

                    if (prospect != null)
                    {
                        if (prospect.Businesses != null)
                        {
                            foreach (var business in prospect.Businesses.ToList())
                            {
                                if (business.Id == BusinessId)
                                {
                                    foreach (var coverage in business.Coverages.ToList())
                                    {
                                        dbContext.Coverages.Remove(coverage);
                                    }

                                    dbContext.Addresses.Remove(business.Address);
                                    dbContext.Businesses.Remove(business);
                                    dbContext.SaveChanges();
                                }
                                else
                                {
                                    return "Business Not Found";
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        return "prospect Not Found";
                    }
                }
            }
            catch (Exception)
            {
                throw new DatabaseException("Unable to remove Businesses");
            }

            return "Succesfully deleted";
        }

        public static string UpdateBusiness(string OrganisationName, Business UpdatedBusiness)
        {
            Prospect prospect;
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    prospect = dbContext.Prospects
                                .Include("Businesses")
                                .Include("Businesses.Address")
                                .Include("Businesses.Coverages")
                                .Where(p => p.OrganisationName == OrganisationName)
                                .FirstOrDefault();

                    if (prospect != null)
                    {
                        if (prospect.Businesses != null)
                        {
                            Business business = dbContext.Businesses.Where(b => b.Id == UpdatedBusiness.Id).FirstOrDefault();
                            if (business == null)
                            {
                                return "business does not exist";
                            }

                            business.IndustryType = UpdatedBusiness.IndustryType;
                            business.Territory = UpdatedBusiness.Territory;
                            business.Exposure = UpdatedBusiness.Exposure;
                            business.Address.FirstLine = UpdatedBusiness.Address.FirstLine;
                            business.Address.SecondLine = UpdatedBusiness.Address.SecondLine;
                            business.Address.City = UpdatedBusiness.Address.City;
                            business.Address.State = UpdatedBusiness.Address.State;
                            business.Address.ZipCode = UpdatedBusiness.Address.ZipCode;

                            int i = 0;

                            foreach (var coverage in business.Coverages.ToList())
                            {
                                coverage.AggregateLimit = UpdatedBusiness.Coverages.ElementAt(i).AggregateLimit;
                                coverage.CoverageName = UpdatedBusiness.Coverages.ElementAt(i).CoverageName;
                                coverage.Deductible = UpdatedBusiness.Coverages.ElementAt(i).Deductible;
                                coverage.CoveragePremium = UpdatedBusiness.Coverages.ElementAt(i).CoveragePremium;
                                coverage.OccuranceLimit = UpdatedBusiness.Coverages.ElementAt(i).OccuranceLimit;
                                i++;
                            }

                            //business.Coverages = UpdatedBusiness.Coverages;
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            return "business Details Not Found";
                        }
                    }
                    else
                    {
                        return "prospect Not Found";
                    }
                }
            }
            catch (Exception)
            {
                throw new DatabaseException("Unable to Update Businesses");
            }

            return "Succesfully Updated";
        }

        public static List<Business> ViewAllBusiness(string OrganisationName)
        {
            try
            {
                Prospect prospect;
                List<Business> businesses;
                using (var dbContext = new QuoteDataModelContainer())
                {
                    prospect = dbContext.Prospects
                                 .Include("Businesses")
                                .Include("Businesses.Address")
                                .Include("Businesses.Coverages")
                                .Where(p => p.OrganisationName == OrganisationName).FirstOrDefault();
                    if(prospect == null)
                    {
                        return new List<Business>();
                    }

                    businesses = prospect.Businesses.ToList();
                    return businesses;
                }
            }
            catch (Exception)
            {
                throw new DatabaseException("unable to view businesses");
            }
        }

        public static Business ViewBusiness(string OrganisationName, int BusinessId)
        {
           
            try
            {
                Prospect prospect;
                using (var dbContext = new QuoteDataModelContainer())
                {
                    prospect = dbContext.Prospects
                                .Include("Businesses")
                               .Include("Businesses.Address")
                               .Include("Businesses.Coverages")
                               .Where(p => p.OrganisationName == OrganisationName).FirstOrDefault();

                    if(prospect == null)
                    {
                        return null;
                    }
                    foreach (var business1 in prospect.Businesses.ToList())
                    {
                        if (business1.Id == BusinessId)
                        {
                            return business1;
                        }
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                throw new DatabaseException("Unable to View the business");
            }
        }

    }
}
