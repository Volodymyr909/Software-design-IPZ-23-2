

public class Reporting
{
    public void RegisterIncome(string productName, int quantity)
    {
        Console.WriteLine($"Прибуткова накладна: {productName}, {quantity} шт");
        Console.WriteLine($"Товар {productName} зареєстровано як отриманий.");
    }

    public void RegisterShipment(string productName, int quantity)
    {
        Console.WriteLine($"Видаткова накладна: {productName}, {quantity} шт");
        Console.WriteLine($"Товар {productName} зареєстровано як відвантажений.");
    }

    public void InventoryReport(Warehouse warehouse)
    {
        Console.WriteLine("Звіт по інвентаризації:");
        warehouse.ListProducts();
    }
}
