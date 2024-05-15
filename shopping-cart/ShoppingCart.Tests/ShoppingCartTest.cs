using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace ShoppingCart.Tests;

public class ShoppingCartTest
{
    private ProductsRepository _productsRepository;
    private Notifier _notifier;
    private ShoppingCart _shoppingCart;
    private CheckoutService _checkoutService;

    [SetUp]
    public void SetUp()
    {
        _productsRepository = Substitute.For<ProductsRepository>();
        _notifier = Substitute.For<Notifier>();
        _checkoutService = Substitute.For<CheckoutService>();
        _shoppingCart = new(_productsRepository, _notifier, _checkoutService);
    }

    [Test]
    public void add_not_available_product()
    {
        _productsRepository.Get("some_item").ReturnsNull();

        _shoppingCart.AddItem("some_item");

        _notifier.Received(1).ShowError("Product is not available");
    }


    [Test]
    public void add_available_product()
    {
        var productName = "Iceberg";
        var cost = 1.55m;
        _productsRepository.Get(productName).Returns(new Product(productName, cost, 0, 0));

        _shoppingCart.AddItem(productName);
        _shoppingCart.Checkout();

        var cart = new ShoppingCartDto(cost);
        _checkoutService.Received(1).Checkout(cart);
    }
}