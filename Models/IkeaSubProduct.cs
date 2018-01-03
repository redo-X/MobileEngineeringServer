public class IkeaSubProduct {
    public IkeaSubProduct()
    {
    }

    public IkeaSubProduct(string partNumber, int quantity)
    {
        PartNumber = partNumber;
        Quantity = quantity;
    }

    public string PartNumber { get; set; }
    public int Quantity { get; set; }
}