using System.Collections.Generic;
using CoffeeMachineApp.core;

namespace CoffeeMachineApp.infrastructure;

public class InMemoryDrinkPrices : DrinkPrices
{
    private readonly Dictionary<DrinkType, decimal> _prices;

    public InMemoryDrinkPrices(Dictionary<DrinkType, decimal> prices)
    {
        _prices = prices;
    }

    public decimal GetDrinkTypePrice(DrinkType drinkType)
    {
        return _prices[drinkType];
    }
}