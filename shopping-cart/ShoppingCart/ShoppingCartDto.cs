namespace ShoppingCart;

public record ShoppingCartDto
{
    private readonly decimal _totalCost;

    public ShoppingCartDto(decimal totalCost)
    {
        _totalCost = totalCost;
    }
}