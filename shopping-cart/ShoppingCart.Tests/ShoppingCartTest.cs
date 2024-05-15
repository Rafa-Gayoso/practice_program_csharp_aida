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
        _shoppingCart = new ShoppingCart(_productsRepository, _notifier, _checkoutService);
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
        const string productName = "Iceberg";
        const decimal cost = 1.55m;
        _productsRepository.Get(productName).Returns(new Product(productName, cost, 0, 0));

        _shoppingCart.AddItem(productName);
        _shoppingCart.Checkout();

        var cart = new ShoppingCartDto(cost);
        _checkoutService.Received(1).Checkout(cart);
    }

    [Test]
    public void add_available_two_products() {
        const string Iceberg = "Iceberg";
        const string Tomato = "Tomato";
        const decimal IcebergCost = 1.55m;
        const decimal TomatoCost = 1m;
        _productsRepository.Get(Iceberg).Returns(new Product(Iceberg, IcebergCost, 0, 0));
        _productsRepository.Get(Tomato).Returns(new Product(Tomato, TomatoCost, 0, 0));

        _shoppingCart.AddItem(Iceberg);
        _shoppingCart.AddItem(Tomato);
        _shoppingCart.Checkout();

        var cart = new ShoppingCartDto(IcebergCost + TomatoCost);
        _checkoutService.Received(1).Checkout(cart);
    }

}