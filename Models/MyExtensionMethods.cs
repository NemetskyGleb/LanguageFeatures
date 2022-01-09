namespace LanguageFeatures.Models;

public static class MyExtesionMethods
{
    public static decimal TotalPrices(this ShoppingCart cartParam)
    {
        decimal total = 0;
        foreach (Product prod in cartParam.Products)
        {
            total += prod?.Price ?? 0;
        }
        return total;
    }
}