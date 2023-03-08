using System;
using System.Collections.Generic;
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
                Quote quote = dbContext.Quotes.Where(c => c.QuoteNumber == quotenum).FirstOrDefault();

                //Prospect prospect = dbContext.Prospects.Where()

               dbContext.Quotes.Remove(quote);

                dbContext.SaveChanges();
            }

        }


    }
}
