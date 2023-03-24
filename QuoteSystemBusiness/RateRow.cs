using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSystemBusiness
{
    public class RateRow
    {
       public List<RateKey> RateKeys { get; set; }
        public RateFactor RateFactor { get; set; }
    }
}
