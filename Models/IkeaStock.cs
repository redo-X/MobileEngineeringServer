using System.Collections.Generic;

public class IkeaStock
{
    public string StoreId { get; set; }
    public string PartNumber { get; set; }
    public string InStockProbabilityCode { get; set; }

    public bool IsMultiProduct { get; set; }
    public bool IsSoldInStore { get; set; }
    public bool IsInStoreRange { get; set; }

    public int AvailableStock { get; set; }

    public List<IkeaStockProduct> Products { get; set; } = new List<IkeaStockProduct>();
}