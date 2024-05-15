using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart;

public class ShoppingCart
{
    private readonly ProductsRepository _productsRepository;
    private readonly Notifier _notifier;
    private readonly CheckoutService _checkoutService;
    private readonly DiscountRepository _discountsRepository;
    private List<Product> _productList; 

    public ShoppingCart(ProductsRepository productsRepository, Notifier notifier, CheckoutService checkoutService,
        DiscountRepository discountsRepository)
    {
        _productsRepository = productsRepository;
        _notifier = notifier;
        _checkoutService = checkoutService;
        _discountsRepository = discountsRepository;
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
        var shoppingCartDto = new ShoppingCartDto(GetTotalCost());
        _checkoutService.Checkout(shoppingCartDto);
    }

    private decimal GetTotalCost() {
        return _productList.Sum(p => p.GetTotalCost());
    }

    public void ApplyDiscount(DiscountCode discountCode)
    {
        _notifier.ShowError("Discount is not available");
    }
}