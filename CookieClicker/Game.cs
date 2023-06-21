using System.Collections.Generic;

namespace CoockieClicker;

public class Game
{
    public float Bank { get; set; } = 0;
    public float TotalCookies { get; set; } = 0;
    public float CookiesPerClick { get; set; } = 1;
    public List<Building> Buildings { get; private set; } = new();

    public Game()
    {
        Buildings.Add(new Cursor());
        Buildings.Add(new Grandma());
        Buildings.Add(new Farm());
        Buildings.Add(new Mine());
        Buildings.Add(new Factory());
    }

    public void Click()
    {
        this.Bank += CookiesPerClick;
        this.TotalCookies += CookiesPerClick;
    }

    public void Produce()
    {
        float prod = 0;
        foreach (var building in this.Buildings)
            prod += building.TotalProduction;
        this.Bank += prod;
    }
    
    public bool TryBuy(int index)
    {
        var building = getBuilding(index);
        return building?.TryBuy(this) ?? false;
    }

    public bool CanBuy(int index)
    {
        var building = getBuilding(index);
        return building?.CanBuy(this) ?? false;
    }

    private Building getBuilding(int index)
    {
        if (index < 0 || index >= this.Buildings.Count)
            return null;
        return this.Buildings[index];
    }
}