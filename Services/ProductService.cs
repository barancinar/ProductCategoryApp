using System.Net.Http;
using System.Net.Http.Json;
using ProductCategoryApp.Models;

namespace ProductCategoryApp.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categoriesResponse = await _httpClient.GetFromJsonAsync<List<Category>>("https://dummyjson.com/products/categories");
            return categoriesResponse ?? new List<Category>();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            var response = await _httpClient.GetFromJsonAsync<ProductResponse>($"https://dummyjson.com/products/category/{category}");
            return response?.Products ?? new List<Product>(); // Null kontrolü
        }
    }
}
