using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart;

public class ShoppingCart
{
    private readonly ProductsRepository _productsRepository;
    private readonly Notifier _notifier;
    private readonly CheckoutService _checkoutService;
    private List<Product> _productList; 

    public ShoppingCart(ProductsRepository productsRepository, Notifier notifier, CheckoutService checkoutService)
    {
        _productsRepository = productsRepository;
        _notifier = notifier;
        _checkoutService = checkoutService;
        _productList = new List<Product>();
    }

    public void AddItem(string productName)
    {
        var product = _productsRepository.Get(productName);
        if (product is null)
        {
            _notifier.ShowError("Product is not available");
            return;
        }

        _productList.Add(product);

    }

    public void Checkout()
    {
        var shoppingCartDto = new ShoppingCartDto(_productList.Sum(p => p.Cost));
        _checkoutService.Checkout(shoppingCartDto);
    }
}