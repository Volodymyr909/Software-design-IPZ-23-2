using System;
using System.Collections.Generic;

public class Warehouse
{
    public string ProductName { get; set; }
    public string Unit { get; set; }
    public Money UnitPrice { get; set; }
    public int Quantity { get; set; }
    public DateTime LastDeliveryDate { get; set; }
    public List<Product> Products { get; set; }

    public Warehouse(string productName, string unit, Money unitPrice, int quantity, DateTime lastDeliveryDate)
    {
        ProductName = productName;
        Unit = unit;
        UnitPrice = unitPrice;
        Quantity = quantity;
        LastDeliveryDate = lastDeliveryDate;
        Products = new List<Product>();
    }

    public void AddStock(int quantity)
    {
        Quantity += quantity;
    }

    public void ReduceStock(int quantity)
    {
        Quantity -= quantity;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }

    public void ListProducts()
    {
        foreach (var product in Products)
        {
            Console.Write($"Назва: {product.Name}, Категорія: {product.Category}, Бренд: {product.Brand}, Ціна: ");
            product.Price.DisplayAmount();
        }
    }
}
