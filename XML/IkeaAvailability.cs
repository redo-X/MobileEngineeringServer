using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace MobileEngineeringServer.XML.Availability
{
	[XmlRoot(ElementName="findIt")]
	public class FindIt {
		[XmlElement(ElementName="partNumber")]
		public string PartNumber { get; set; }
		[XmlElement(ElementName="quantity")]
		public string Quantity { get; set; }
		[XmlElement(ElementName="type")]
		public string Type { get; set; }
		[XmlElement(ElementName="box")]
		public string Box { get; set; }
		[XmlElement(ElementName="shelf")]
		public string Shelf { get; set; }
		[XmlElement(ElementName="specialityShop")]
		public string SpecialityShop { get; set; }
	}

	[XmlRoot(ElementName="findItList")]
	public class FindItList {
		[XmlElement(ElementName="findIt", Namespace = "")]
		public List<FindIt> FindIt { get; set; }
	}

	[XmlRoot(ElementName="stock")]
	public class Stock {
		[XmlElement(ElementName="partNumber")]
		public string PartNumber { get; set; }
		[XmlElement(ElementName="isMultiProduct")]
		public string IsMultiProduct { get; set; }
		[XmlElement(ElementName="isSoldInStore")]
		public string IsSoldInStore { get; set; }
		[XmlElement(ElementName="isInStoreRange")]
		public string IsInStoreRange { get; set; }
		[XmlElement(ElementName="availableStock")]
		public string AvailableStock { get; set; }
		[XmlElement(ElementName="inStockProbabilityCode")]
		public string InStockProbabilityCode { get; set; }
		[XmlElement(ElementName="validDate")]
		public string ValidDate { get; set; }
		[XmlElement(ElementName="findItList", Namespace = "")]
		public FindItList FindItList { get; set; }
		[XmlElement(ElementName="isValidForNotification")]
		public string IsValidForNotification { get; set; }
	}

	[XmlRoot(ElementName="localStore")]
	public class LocalStore {
		[XmlElement(ElementName="stock", Namespace = "")]
		public Stock Stock { get; set; }
		[XmlAttribute(AttributeName="buCode")]
		public string BuCode { get; set; }
		[XmlAttribute(AttributeName="timeZoneOffsetInMillis")]
		public string TimeZoneOffsetInMillis { get; set; }
	}

	[XmlRoot(ElementName="availability")]
	public class Availability {
		[XmlElement(ElementName="localStore", Namespace = "")]
		public List<LocalStore> LocalStore { get; set; }
	}

	[XmlRoot(ElementName="ikea-rest", Namespace="http://www.ikea.com/v1.0")]
	public class Ikearest {
		[XmlElement(ElementName="availability", Namespace = "")]
		public Availability Availability { get; set; }
	}

}
