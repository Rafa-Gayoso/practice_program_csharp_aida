namespace ShoppingCart;

public class ShoppingCart
{
    private readonly ProductsRepository _productsRepository;
    private readonly Notifier _notifier;

    public ShoppingCart(ProductsRepository productsRepository, Notifier notifier)
    {
        _productsRepository = productsRepository;
        _notifier = notifier;
    }

    public void AddItem(string productName)
    {
        _notifier.ShowError("Product is not available");
    }
}