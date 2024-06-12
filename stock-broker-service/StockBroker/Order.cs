namespace StockBroker;

public class Order
{
    private readonly int _quantity;
    private readonly decimal _value;
    public OrderOperation Operation { get; }

    public Order(int quantity, decimal value, OrderOperation operation)
    {
        _quantity = quantity;
        _value = value;
        Operation = operation;
    }

    public decimal CalculateOrderAmount()
    {
        return _quantity * _value;
    }
}