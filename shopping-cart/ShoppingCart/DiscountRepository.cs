namespace ShoppingCart;

public interface DiscountRepository
{
    Discount Get(DiscountCode promo20);
}