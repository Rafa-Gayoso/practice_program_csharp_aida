using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using static ShoppingCart.Tests.ProductBuilder;

namespace ShoppingCart.Tests;

public class ShoppingCartTest
{
    private ProductsRepository _productsRepository;
    private Notifier _notifier;
    private ShoppingCart _shoppingCart;
    private CheckoutService _checkoutService;
    private DiscountRepository _discountsRepository;

    [SetUp]
    public void SetUp()
    {
        _productsRepository = Substitute.For<ProductsRepository>();
        _notifier = Substitute.For<Notifier>();
        _checkoutService = Substitute.For<CheckoutService>();
        _discountsRepository = Substitute.For<DiscountRepository>();
        _shoppingCart = new ShoppingCart(_productsRepository, _notifier, _checkoutService, _discountsRepository);
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
        _productsRepository.Get(productName).Returns(
            TaxFreeWithNoRevenueProduct().Named(productName).Costing(cost).Build());

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
        _productsRepository.Get(Iceberg).Returns(
            TaxFreeWithNoRevenueProduct().Named(Iceberg).Costing(IcebergCost).Build());
        _productsRepository.Get(Tomato).Returns(
            TaxFreeWithNoRevenueProduct().Named(Tomato).Costing(TomatoCost).Build());

        _shoppingCart.AddItem(Iceberg);
        _shoppingCart.AddItem(Tomato);
        _shoppingCart.Checkout();

        var cart = new ShoppingCartDto(IcebergCost + TomatoCost);
        _checkoutService.Received(1).Checkout(cart);
    }

    [Test]
    public void add_available_one_product_with_tax() {
        const string productName = "Iceberg";
        const decimal cost = 1m;
        _productsRepository.Get(productName).Returns(
            NoRevenueProduct()
                .Named(productName)
                .WithTax(0.10m)
                .Costing(cost)
                .Build());

        _shoppingCart.AddItem(productName);
        _shoppingCart.Checkout();

        var cart = new ShoppingCartDto(1.10m);
        _checkoutService.Received(1).Checkout(cart);
    }

    [Test]
    public void add_available_one_product_with_revenue()
    {
        const string productName = "Iceberg";
        const decimal cost = 2m;
        _productsRepository.Get(productName).Returns(
            NoTaxProduct()
                .Named(productName)
                .WithRevenue(0.05m)
                .Costing(cost)
                .Build());

        _shoppingCart.AddItem(productName);
        _shoppingCart.Checkout();

        var cart = new ShoppingCartDto(2.10m);
        _checkoutService.Received(1).Checkout(cart);
    }

    [Test]
    public void add_available_one_product_with_revenue_and_tax()
    {
        const string productName = "Iceberg";
        const decimal cost = 2m;
        _productsRepository.Get(productName).Returns(
            AnyProduct()
                .Named(productName)
                .WithRevenue(0.05m)
                .WithTax(0.1m)
                .Costing(cost)
                .Build());

        _shoppingCart.AddItem(productName);
        _shoppingCart.Checkout();

        var cart = new ShoppingCartDto(2.31m);
        _checkoutService.Received(1).Checkout(cart);
    }

    [Test]
    public void apply_not_available_discount()
    {
        _discountsRepository.Get(DiscountCode.PROMO_20).ReturnsNull();

        _shoppingCart.ApplyDiscount(DiscountCode.PROMO_20);

        _notifier.Received(1).ShowError("Discount is not available");
    }

    [Test]
    [Ignore("XXXXX")]
    public void apply_available_discount()
    {
        _discountsRepository.Get(DiscountCode.PROMO_20).ReturnsNull();

        _shoppingCart.ApplyDiscount(DiscountCode.PROMO_20);

        _notifier.Received(1).ShowError("Discount is not available");
    }
}