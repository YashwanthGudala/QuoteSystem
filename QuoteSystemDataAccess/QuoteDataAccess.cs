using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using log4net;
namespace QuoteSystemDataAccess
{
    public class QuoteDataAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string GenerateQuoteNumber()
        {
            string year = DateTime.Now.Year.ToString();
            year = year.Substring(year.Length - 2);

            string LastQuoteNumber;
            string NewQuoteNumber;

            try
            {
                using (var dbContext = new QuoteDataModelContainer())
                {
                    Quote quote = dbContext.Quotes.OrderByDescending(e => e.Id).First();
                    LastQuoteNumber = quote.QuoteNumber;
                }
                var LastQuoteList = LastQuoteNumber.Split('-');

                int LastQuoteNum = Convert.ToInt32(LastQuoteList[1]);
                LastQuoteNum += 1;

                NewQuoteNumber = "Q" + year + "CGL" + "-" + LastQuoteNum.ToString().PadLeft(4, '0');
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                throw new DatabaseException("Unable To Generate Quote Number");
            }

            log.Info("Generated New Quote Number : " + NewQuoteNumber);
            return NewQuoteNumber;

        }
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
                    if (status != null)
                    {
                        return "Quote Already Exists !!";
                    }
                    quote.QuoteNumber = GenerateQuoteNumber();
                    dbContext.Quotes.Add(quote);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                throw new DatabaseException("Unable To Add New Quote To Database");
            }
            log.Info("Added New Quote With Quote Number : " + quote.QuoteNumber);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);

                throw new DatabaseException("Unable To Fetch the Quote From Database");
            }
            log.Info("Viewed Quote Details of Quote Number : " + QuoteNumber);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);

                throw new DatabaseException("Unable To Fetch Quotes From Database");
            }
            log.Info("Viewed All Quote Details");
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to Delete Quote From Database");
            }

            log.Info("Deleted Quote With Quote Number : " + quotenum);
            return "Successfully Deleted";


        }

        public static string UpdateQuote(Quote UpdatedQuote)
        {
            if (UpdatedQuote == null)
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
                            OldQuote.AgentId = UpdatedQuote.AgentId;

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
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new DatabaseException("Unable to Update Quote , Something Went Wrong");
            }
            log.Info("Updated Quote Details of Quote Number : " + UpdatedQuote.QuoteNumber);
            return "Successfully Updated";

        }

        


    }


}

