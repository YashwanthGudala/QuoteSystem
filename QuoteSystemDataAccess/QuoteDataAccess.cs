using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;

namespace QuoteSystemDataAccess
{
    public class QuoteDataAccess
    {
        public static string AddQuote(Quote quote)
        {
            if (quote == null)
            {
                return "Unable to add Null Quote ";
            }
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    Quote status = dbContext.Quotes.Where(c => c.QuoteNumber == quote.QuoteNumber).FirstOrDefault();
                    if(status != null)
                    {
                        return "Quote Already Exists !!";
                    }
                    dbContext.Quotes.Add(quote);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                

                throw new DatabaseException("Unable To Add New Quote To Database");
            }
            return "Successfully Added";


        }
        public static Quote ViewQuote(string QuoteNumber)
        {
            Quote quote;
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    quote = dbContext.Quotes
                        .Include("Prospect")
                        .Include("PolicyTerm")
                        .Include("Prospect.Businesses")
                        .Include("Prospect.Businesses.Address")
                        .Include("Prospect.Businesses.Coverages")
                        .Where(Q => Q.QuoteNumber == QuoteNumber).FirstOrDefault<Quote>();
                }
            }
            catch (Exception)
            {

                throw new DatabaseException("Unable To Fetch the Quote From Database");
            }
            return quote;
        }
        public static List<Quote> ViewAllQuote()
        {
            List<Quote> Quotes;
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    Quotes = dbContext.Quotes
                             .Include("Prospect")
                             .Include("PolicyTerm")
                             .Include("Prospect.Businesses")
                             .Include("Prospect.Businesses.Address")
                             .Include("Prospect.Businesses.Coverages")
                             .ToList<Quote>();
                }
            }
            catch (Exception)
            {

                throw new DatabaseException("Unable To Fetch Quotes From Database");
            }
            return Quotes;
        }

        public static string DeleteQuote(string quotenum)
        {
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    Quote quote = dbContext.Quotes
                        .Include("Prospect")
                        .Include("PolicyTerm")
                        .Include("Prospect.Businesses")
                        .Include("Prospect.Businesses.Address")
                        .Include("Prospect.Businesses.Coverages")
                        .Where(c => c.QuoteNumber == quotenum)
                        .FirstOrDefault();

                    if (quote != null)
                    {
                        if (quote.Prospect != null)
                        {
                            dbContext.PolicyTerms.Remove(quote.PolicyTerm);

                            foreach (var business in quote.Prospect.Businesses.ToList())

                            {
                                foreach (var coverage in business.Coverages.ToList())
                                {
                                    dbContext.Coverages.Remove(coverage);
                                }
                                dbContext.Addresses.Remove(business.Address);
                                dbContext.Businesses.Remove(business);
                            }
                            dbContext.Prospects.Remove(quote.Prospect);
                        }
                        else
                        {
                            return "Prospect Details Not Found";
                        }

                        dbContext.Quotes.Remove(quote);
                    }
                    else
                    {
                        return "Quote Not Found";
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw new DatabaseException("Unable to Delete Quote From Database");
            }

            return "Successfully Deleted";

                
        }
       
        public static string UpdateQuote(Quote UpdatedQuote)
        {
            if(UpdatedQuote == null)
            {
                return "Unable to Update a null quote";
            }
            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    Quote OldQuote = dbContext.Quotes
                        .Include("Prospect")
                        .Include("PolicyTerm")
                        .Include("Prospect.Businesses")
                        .Include("Prospect.Businesses.Address")
                        .Include("Prospect.Businesses.Coverages")
                        .Where(c => c.QuoteNumber == UpdatedQuote.QuoteNumber)
                        .FirstOrDefault();

                    if (OldQuote != null)
                    {
                        if (OldQuote.Prospect != null)
                        {
                            OldQuote.PolicyTerm.PolicyEffectiveDate = UpdatedQuote.PolicyTerm.PolicyEffectiveDate;
                            OldQuote.PolicyTerm.PolicyExpiryDate = UpdatedQuote.PolicyTerm.PolicyExpiryDate;

                            OldQuote.Premium = UpdatedQuote.Premium;
                            OldQuote.RiskState = UpdatedQuote.RiskState;

                            OldQuote.Prospect.Contact = UpdatedQuote.Prospect.Contact;
                            OldQuote.Prospect.Email = UpdatedQuote.Prospect.Email;
                            OldQuote.Prospect.NumberOfBusinessUnits = UpdatedQuote.Prospect.NumberOfBusinessUnits;
                            OldQuote.Prospect.OrganisationName = UpdatedQuote.Prospect.OrganisationName;

                            foreach (var business in OldQuote.Prospect.Businesses.ToList())
                            {

                                foreach (var coverage in business.Coverages.ToList())
                                {
                                    dbContext.Coverages.Remove(coverage);
                                }

                                dbContext.Addresses.Remove(business.Address);
                                dbContext.Businesses.Remove(business);
                            }

                            foreach (var business in UpdatedQuote.Prospect.Businesses)
                            {
                                OldQuote.Prospect.Businesses.Add(business);

                            }


                        }
                        else
                        {
                            return "Prospect Details Not Found";
                        }
                    }
                    else
                    {
                        return "Quote Not Found";
                    }
                    dbContext.SaveChanges();

                };
            }
            catch (Exception)
            {
                
                throw new DatabaseException("Unable to Update Quote , Something Went Wrong");
            }
            return "Successfully Updated";

        }


        }


    }

