using HtmlParserSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuoteSystemBusiness
{
	[XmlRoot(ElementName = "RateKey")]
	public class RateKey
	{

		[XmlElement(ElementName = "KeyName")]
		public string KeyName { get; set; }

		[XmlElement(ElementName = "KeyValue")]
		public string KeyValue { get; set; }
	}

	[XmlRoot(ElementName = "RateKeys")]
	public class RateKeys
	{

		[XmlElement(ElementName = "RateKey")]
		public List<RateKey> RateKey { get; set; }
	}

	[XmlRoot(ElementName = "RateFactor")]
	public class RateFactor
	{

		[XmlElement(ElementName = "FactorName")]
		public string FactorName { get; set; }

		[XmlElement(ElementName = "FactorValue")]
		public double FactorValue { get; set; }
	}

	[XmlRoot(ElementName = "RateRow")]
	public class RateRow
	{

		[XmlElement(ElementName = "RateKeys")]
		public RateKeys RateKeys { get; set; }

		[XmlElement(ElementName = "RateFactor")]
		public RateFactor RateFactor { get; set; }
	}

	[XmlRoot(ElementName = "RateTable")]
	public class RateTable
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "RateRow")]
		public List<RateRow> RateRow { get; set; }
	}

	[XmlRoot(ElementName = "RateTables")]
	public class RateTables
	{

		[XmlElement(ElementName = "RateTable")]
		public List<RateTable> RateTable { get; set; }
	}

	[XmlRoot(ElementName = "RateMetaData")]
	public class RateMetaData
	{

		[XmlElement(ElementName = "RateTables")]
		public RateTables RateTables { get; set; }
	}


}
