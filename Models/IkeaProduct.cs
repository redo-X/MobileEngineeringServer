

using System.Collections.Generic;

public class IkeaProduct
{
    public string ParentUrl { get; set; }
    public string ParentPartNumber { get; set; }
    public string ParentDisplayName { get; set; }
    public string ParentDisplayNameSweden { get; set; }

    public string PartNumber { get; set; }
    public string Url { get; set; }
    public string DisplayName { get; set; }
    public string DisplayNameSweden { get; set; }
    public bool IsNew { get; set; }
    public bool IsBti {get;set;}
    public string Facts { get; set; }
    public string CareInstructions { get; set; }
    public string CustomerBenefit { get; set; }
    public string Designer { get; set; }
    public string Environment { get; set; }
    public string GoodToKnow { get; set; }
    public string CustomerMaterials { get; set; }
    public int NumberOfPackages { get; set; }
    public bool RequireAssembly { get; set; }
    public string Type { get; set; }
    public string Measure { get; set; }

    public decimal? NormalPrice { get; set; }
    public decimal? SecondPrice { get; set; }
    public decimal? FamilyNormalPrice { get; set; }

    public List<IkeaSubProduct> SubProducts { get; set; } = new List<IkeaSubProduct>();
    public List<string> SmallImageUrls { get; set; } = new List<string>();
    public List<string> LargeImageUrls { get; set; } = new List<string>();
}