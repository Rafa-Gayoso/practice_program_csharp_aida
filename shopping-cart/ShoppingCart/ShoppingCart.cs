namespace ShoppingCart;

public class ShoppingCart
{
    private readonly ProductsRepository _productsRepository;
    private readonly Notifier _notifier;
    private readonly CheckoutService _checkoutService;

    public ShoppingCart(ProductsRepository productsRepository, Notifier notifier, CheckoutService checkoutService)
    {
        _productsRepository = productsRepository;
        _notifier = notifier;
        _checkoutService = checkoutService;
    }

    public void AddItem(string productName)
    {
        var product = _productsRepository.Get(productName);
        if (product is null)
        {
            _notifier.ShowError("Product is not available");
            return;
        }

        _checkoutService.Checkout(new ShoppingCartDto(product.Cost));
    }

    public void Checkout()
    {
        
    }
}