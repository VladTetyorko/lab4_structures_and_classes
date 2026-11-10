namespace Task1.ShopSimulation.Catalog;

public readonly struct ProductDescription
{
    internal ProductDescription(string name, decimal unitPrice, int availableQuantity, MeasureUnit unit)
    {
        Name = name;
        UnitPrice = unitPrice;
        AvailableQuantity = availableQuantity;
        Unit = unit;
    }

    public string Name { get; }

    public decimal UnitPrice { get; }

    public int AvailableQuantity { get; }

    public MeasureUnit Unit { get; }
}
