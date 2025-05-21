using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Створення об'єктів класу Product
        Product laptop = new Product("Ноутбук", new Money(1000, 50), "Електроніка", "Dell");
        Product phone = new Product("Телефон", new Money(800, 75), "Електроніка", "Samsung");

        // Виведення ціни продуктів
        Console.Write($"Ціна продукту {laptop.Name}:");
        laptop.Price.DisplayAmount();

        laptop.ReducePrice(100);
        Console.Write($"Нова ціна продукту {laptop.Name}:");
        laptop.Price.DisplayAmount();

        // Створення об'єкту класу Warehouse
        Warehouse warehouse = new Warehouse("Техніка", "шт.", new Money(0, 0), 0, DateTime.Now);
        warehouse.AddProduct(laptop);
        warehouse.AddProduct(phone);

        // Створення об'єкту класу Reporting
        Reporting reporting = new Reporting();
        reporting.RegisterIncome(laptop.Name, 10);
        reporting.RegisterIncome(phone.Name, 20);
        reporting.RegisterShipment(laptop.Name, 3);

        reporting.InventoryReport(warehouse);

        // Зупинка консолі
        Console.ReadKey();
    }
}
