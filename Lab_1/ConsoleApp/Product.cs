public class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }

    public Product(string name, Money price, string category, string brand)
    {
        Name = name;
        Price = price;
        Category = category;
        Brand = brand;
    }

    public void ReducePrice(int amount)
    {
        int totalMinor = Price.WholePart * 100 + Price.FractionalPart - amount;
        Price.WholePart = totalMinor / 100;
        Price.FractionalPart = totalMinor % 100;
    }

    public void IncreasePrice(int amount)
    {
        int totalMinor = Price.WholePart * 100 + Price.FractionalPart + amount;
        Price.WholePart = totalMinor / 100;
        Price.FractionalPart = totalMinor % 100;
    }
}
