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
        public static void AddQuote(Quote quote)
        {
            using(var dbContext = new QuoteDataModelContainer())
            {
                dbContext.Quotes.Add(quote);

                dbContext.SaveChanges();
            }


        }
        public static Quote ViewQuote(string QuoteNumber)
        {
            Quote quote;
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
            return quote;
        }
        public static List<Quote> ViewAllQuote()
        {
            List<Quote> Quotes;
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
            return Quotes;
        }

        public static void DeleteQuote(string quotenum)
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

                if(quote != null)
                {
                    if(quote.Prospect != null)
                    {
                        dbContext.PolicyTerms.Remove(quote.PolicyTerm);

                        foreach(var business in quote.Prospect.Businesses.ToList())

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
                    
                    dbContext.Quotes.Remove(quote);
                }
               
                dbContext.SaveChanges();
            }

                
        }
       
        public static void UpdateQuote(Quote UpdatedQuote)
        {
            using(var dbContext = new QuoteDataModelContainer())
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
                    if(OldQuote.Prospect != null)
                    {
                        OldQuote.PolicyTerm.PolicyEffectiveDate = UpdatedQuote.PolicyTerm.PolicyEffectiveDate;
                        OldQuote.PolicyTerm.PolicyExpiryDate = UpdatedQuote.PolicyTerm.PolicyExpiryDate;

                        OldQuote.Premium = UpdatedQuote.Premium;
                        OldQuote.RiskState = UpdatedQuote.RiskState;

                        OldQuote.Prospect.Contact = UpdatedQuote.Prospect.Contact;
                        OldQuote.Prospect.Email = UpdatedQuote.Prospect.Email;
                        OldQuote.Prospect.NumberOfBusinessUnits = UpdatedQuote.Prospect.NumberOfBusinessUnits;
                        OldQuote.Prospect.OrganisationName = UpdatedQuote.Prospect.OrganisationName;

                        foreach(var business in OldQuote.Prospect.Businesses.ToList())
                        {
                            
                            foreach(var coverage in business.Coverages.ToList())
                            {
                                dbContext.Coverages.Remove(coverage);
                            }

                            dbContext.Addresses.Remove(business.Address);
                            dbContext.Businesses.Remove(business);
                        }

                        foreach(var business in UpdatedQuote.Prospect.Businesses)
                        {
                            OldQuote.Prospect.Businesses.Add(business);

                        } 

                        
                    }
                }
                dbContext.SaveChanges();

            };

        }


        }


    }

