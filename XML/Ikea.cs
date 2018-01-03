using System.Collections.Generic;
using System.Xml.Serialization;

namespace MobileEngineeringServer.XML
{
    [XmlRoot(ElementName = "header")]
    public class Header
    {
        [XmlElement(ElementName = "requestCommand")]
        public string RequestCommand { get; set; }
        [XmlElement(ElementName = "responseType")]
        public string ResponseType { get; set; }
        [XmlElement(ElementName = "datasets")]
        public string Datasets { get; set; }
    }

    [XmlRoot(ElementName = "attributeItem")]
    public class AttributeItem
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "attributesItems")]
    public class AttributesItems
    {
        [XmlElement(ElementName = "attributeItem")]
        public List<AttributeItem> AttributeItem { get; set; }
    }

    [XmlRoot(ElementName = "image")]
    public class Image
    {
        [XmlAttribute(AttributeName = "height")]
        public string Height { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "small")]
    public class Small
    {
        [XmlElement(ElementName = "image", Namespace = "")]
        public Image Image { get; set; }
    }

    [XmlRoot(ElementName = "thumb")]
    public class Thumb
    {
        [XmlElement(ElementName = "image", Namespace = "")]
        public Image Image { get; set; }
    }

    [XmlRoot(ElementName = "normal")]
    public class Normal
    {
        [XmlElement(ElementName = "image", Namespace = "")]
        public List<Image> Image { get; set; }
        [XmlElement(ElementName = "priceNormal", Namespace = "")]
        public PriceNormal PriceNormal { get; set; }
        [XmlElement(ElementName = "pricePrevious")]
        public string PricePrevious { get; set; }
        [XmlElement(ElementName = "priceNormalPerUnit")]
        public string PriceNormalPerUnit { get; set; }
        [XmlElement(ElementName = "pricePreviousPerUnit")]
        public string PricePreviousPerUnit { get; set; }
    }

    [XmlRoot(ElementName = "large")]
    public class Large
    {
        [XmlElement(ElementName = "image", Namespace = "")]
        public List<Image> Image { get; set; }
    }

    [XmlRoot(ElementName = "zoom")]
    public class Zoom
    {
        [XmlElement(ElementName = "image", Namespace = "")]
        public List<Image> Image { get; set; }
    }

    [XmlRoot(ElementName = "images")]
    public class Images
    {
        [XmlElement(ElementName = "small")]
        public Small Small { get; set; }
        [XmlElement(ElementName = "thumb")]
        public Thumb Thumb { get; set; }
        [XmlElement(ElementName = "normal")]
        public Normal Normal { get; set; }
        [XmlElement(ElementName = "large")]
        public Large Large { get; set; }
        [XmlElement(ElementName = "zoom")]
        public Zoom Zoom { get; set; }
    }

    [XmlRoot(ElementName = "priceNormal")]
    public class PriceNormal
    {
        [XmlAttribute(AttributeName = "unformatted")]
        public string Unformatted { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "second")]
    public class Second
    {
        [XmlElement(ElementName = "priceNormal", Namespace = "")]
        public PriceNormal PriceNormal { get; set; }
        [XmlElement(ElementName = "priceChanged")]
        public string PriceChanged { get; set; }
        [XmlElement(ElementName = "priceNormalPerUnit")]
        public string PriceNormalPerUnit { get; set; }
        [XmlElement(ElementName = "priceChangedPerUnit")]
        public string PriceChangedPerUnit { get; set; }
    }

    [XmlRoot(ElementName = "family-normal")]
    public class Familynormal
    {
        [XmlElement(ElementName = "priceNormal", Namespace = "")]
        public PriceNormal PriceNormal { get; set; }
    }

    [XmlRoot(ElementName = "prices")]
    public class Prices
    {
        [XmlElement(ElementName = "normal", Namespace = "")]
        public Normal Normal { get; set; }
        [XmlElement(ElementName = "second", Namespace = "")]
        public Second Second { get; set; }
        [XmlElement(ElementName = "family-normal", Namespace = "")]
        public Familynormal Familynormal { get; set; }
    }

    [XmlRoot(ElementName = "article")]
    public class Article
    {
        [XmlAttribute(AttributeName = "partNumber")]
        public string PartNumber { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
    }

    [XmlRoot(ElementName = "subItems")]
    public class SubItems
    {
        [XmlElement(ElementName = "article", Namespace = "")]
        public List<Article> Article { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "partNumber")]
        public string PartNumber { get; set; }
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "new")]
        public string New { get; set; }
        [XmlElement(ElementName = "facts")]
        public string Facts { get; set; }
        [XmlElement(ElementName = "bti")]
        public string Bti { get; set; }
        [XmlElement(ElementName = "buyable")]
        public string Buyable { get; set; }

        [XmlElement(ElementName = "nameswe")]
        public string Nameswe { get; set; }
        [XmlElement(ElementName = "careInst")]
        public string CareInst { get; set; }
        [XmlElement(ElementName = "custBenefit")]
        public string CustBenefit { get; set; }
        [XmlElement(ElementName = "designer")]
        public string Designer { get; set; }
        [XmlElement(ElementName = "environment")]
        public string Environment { get; set; }
        [XmlElement(ElementName = "goodToKnow")]
        public string GoodToKnow { get; set; }
        [XmlElement(ElementName = "custMaterials")]
        public string CustMaterials { get; set; }
        [XmlElement(ElementName = "nopackages")]
        public string Nopackages { get; set; }
        [XmlElement(ElementName = "reqAssembly")]
        public string ReqAssembly { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "hasProductFiche")]
        public string HasProductFiche { get; set; }
        [XmlElement(ElementName = "measure")]
        public string Measure { get; set; }

        [XmlElement(ElementName = "attributesItems", IsNullable = true, Namespace = "")]
        public AttributesItems AttributesItems { get; set; }

        [XmlElement(ElementName = "images", Namespace = "")]
        public Images Images { get; set; }
        [XmlElement(ElementName = "prices", Namespace = "")]
        public Prices Prices { get; set; }
        [XmlElement(ElementName = "subItems", Namespace = "")]
        public SubItems SubItems { get; set; }
    }

    [XmlRoot(ElementName = "items")]
    public class Items
    {
        [XmlElement(ElementName = "item", Namespace = "")]
        public Item Item { get; set; }
    }

    [XmlRoot(ElementName = "category")]
    public class Category
    {
        [XmlElement(ElementName = "identifier")]
        public string Identifier { get; set; }
        [XmlElement(ElementName = "catalogIdentifier")]
        public string CatalogIdentifier { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }
    }

    [XmlRoot(ElementName = "series")]
    public class Series
    {
        [XmlElement(ElementName = "category", Namespace = "")]
        public Category Category { get; set; }
    }

    [XmlRoot(ElementName = "parents")]
    public class Parents
    {
        [XmlElement(ElementName = "category", Namespace = "")]
        public Category Category { get; set; }
    }

    [XmlRoot(ElementName = "categories")]
    public class Categories
    {
        [XmlElement(ElementName = "collections")]
        public string Collections { get; set; }
        [XmlElement(ElementName = "systems")]
        public string Systems { get; set; }
        [XmlElement(ElementName = "series", Namespace = "")]
        public Series Series { get; set; }
        [XmlElement(ElementName = "parents", Namespace = "")]
        public Parents Parents { get; set; }
    }

    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }

        [XmlElement(ElementName = "partNumber")]
        public string PartNumber { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "nameswe", IsNullable = true)]
        public string Nameswe { get; set; }

        [XmlElement(ElementName = "items", Namespace = "")]
        public Items Items { get; set; }
        [XmlElement(ElementName = "categories", Namespace = "")]
        public Categories Categories { get; set; }

        [XmlElement(ElementName = "attributes", Namespace = "", IsNullable = true)]
        public Attributes Attributes { get; set; }
    }

    [XmlRoot(ElementName = "attribute")]
    public class Attribute
    {
        [XmlElement(ElementName = "value")]
        public List<string> Value { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "attributes")]
    public class Attributes
    {
        [XmlElement(ElementName = "attribute")]
        public List<Attribute> Attribute { get; set; }
    }

    [XmlRoot(ElementName = "products")]
    public class Products
    {
        [XmlElement(ElementName = "product", Namespace = "")]
        public List<Product> Product { get; set; }
    }

    [XmlRoot(ElementName = "ikea-rest", Namespace = "http://www.ikea.com/v1.0")]
    public class Ikearest
    {
        [XmlElement(ElementName = "header", Namespace = "")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "products", Namespace = "")]
        public Products Products { get; set; }
    }
}
