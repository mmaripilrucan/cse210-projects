using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        total += _customer.IsInUSA() ? 5 : 35;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing List:\n";
        foreach (Product product in _products)
        {
            label += $"- {product.GetPackingInfo()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping To:\n{_customer.GetShippingLabel()}";
    }
}