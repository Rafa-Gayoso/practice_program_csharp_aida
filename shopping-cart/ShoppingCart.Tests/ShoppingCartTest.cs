using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace ShoppingCart.Tests;

public class ShoppingCartTest
{
    private ProductsRepository _productsRepository;
    private Notifier _notifier;

    [SetUp]
    public void SetUp()
    {
        _productsRepository = Substitute.For<ProductsRepository>();
        _notifier = Substitute.For<Notifier>();
    }

    [Test]
    public void add_not_available_product()
    {
        ShoppingCart shoppingCart = new(_productsRepository, _notifier);
        _productsRepository.Get("some_item").ReturnsNull();

        shoppingCart.AddItem("some_item");

        _notifier.Received(1).ShowError("Product is not available");
    }
}

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

public interface Notifier
{
    void ShowError(string message);
}

public interface ProductsRepository
{
    Product Get(string productName);
}

public class Product
{

}
