using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers;

public class HomeController : Controller
{
    bool FilterByPrice(Product p)
    {
        return (p?.Price ?? 0) >= 20;
    }
    public ViewResult Index()
    {
        Product[] productArray = {
            new Product { Name = "Kayak", Price = 275M },
            new Product { Name = "Lifejacket", Price = 48.95M },
            new Product { Name = "Soccer ball", Price = 19.50M },
            new Product { Name = "Corner flag", Price = 34.95M }
        };
        Func<Product, bool> nameFilter = delegate (Product prod) {
            return prod?.Name?[0] == 'S';
        };
        decimal priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();
        decimal nameFilterTotal = productArray.Filter(nameFilter).TotalPrices();
        return View(new string[] {
             $"Total: {priceFilterTotal:C2}",
             $"Total: {nameFilterTotal:C2}"});
    }    
}