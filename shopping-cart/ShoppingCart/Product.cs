namespace ShoppingCart;

public class Product
{
    private readonly string _productName;
    public decimal Cost { get; init; }
    private readonly decimal _revenue;
    private readonly decimal _tax;


    public Product(string productName, decimal cost, decimal revenue, decimal tax)
    {
        _productName = productName;
        Cost = cost;
        _revenue = revenue;
        _tax = tax;
    }
}