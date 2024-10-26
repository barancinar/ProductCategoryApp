using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductCategoryApp.Models;
using ProductCategoryApp.Services;

namespace ProductCategoryApp.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _productService.GetCategoriesAsync();
        return View(categories);
    }

    public async Task<IActionResult> CategoryProducts(string category)
    {
        var products = await _productService.GetProductsByCategoryAsync(category);
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }


}
