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

        }


    }

