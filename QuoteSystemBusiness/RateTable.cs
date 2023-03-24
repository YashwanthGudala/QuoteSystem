using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSystemBusiness
{
    public class RateTable
    {
        public string Name { get; set; }
        public List<RateRow> RateRows { get; set; }
    }
}
