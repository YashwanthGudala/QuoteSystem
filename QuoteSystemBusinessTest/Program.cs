using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemBusiness;
namespace QuoteSystemBusinessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            QuoteSystemBusiness.RatingEngine.LoadMetaData();
            Console.Read();

        }
    }
}
