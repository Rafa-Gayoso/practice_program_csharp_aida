namespace ShoppingCart;

public class Product
{
    private readonly string _productName;

    private readonly decimal _revenue;
    private readonly decimal _tax;
    private readonly decimal _cost;


    public Product(string productName, decimal cost, decimal revenue, decimal tax)
    {
        _productName = productName;
        _cost = cost;
        _revenue = revenue;
        _tax = tax;
    }

    public decimal GetTotalCost() {
        return _cost + _cost*_tax;
    }
}