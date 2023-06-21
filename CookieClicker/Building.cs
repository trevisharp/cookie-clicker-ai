using System;

namespace CoockieClicker;

public abstract class Building
{
    public Building(float basePrice, float baseProduction)
    {
        this.BasePrice = basePrice;
        this.BaseProduction = baseProduction;
    }

    public readonly float BasePrice;
    public readonly float BaseProduction;

    public int Quantity { get; set; }

    public float Price => MathF.Ceiling(
        this.BasePrice * MathF.Pow(1.15f, Quantity)
    );
    public float Production => 0; // TODO
    public float TotalProduction => Quantity * Production;

    public bool TryBuy(Game game)
    {
        var price = this.Price;
        if (game.Bank < price)
            return false;
        
        game.Bank -= price;
        this.Quantity++;
        return true;
    }

    public bool CanBuy(Game game)
        => game.Bank >= this.Price;
}