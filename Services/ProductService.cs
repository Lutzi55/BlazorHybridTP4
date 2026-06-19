using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BlazorHybridTP4.Models;

namespace BlazorHybridTP4.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(List<Product> productos, string status)> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("products");
            string statusMsg = $"{(int)response.StatusCode} {response.ReasonPhrase}";

            if (response.IsSuccessStatusCode)
            {
                var productos = await response.Content.ReadFromJsonAsync<List<Product>>();
                return (productos ?? new List<Product>(), statusMsg);
            }
            return (new List<Product>(), statusMsg);
        }

        public async Task<(Product producto, string status)> CreateProductAsync(Product newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("products/", newProduct);
            string statusMsg = $"{(int)response.StatusCode} {response.ReasonPhrase}";

            if (response.IsSuccessStatusCode)
            {
                var producto = await response.Content.ReadFromJsonAsync<Product>();
                return (producto, statusMsg);
            }
            return (null, statusMsg);
        }

        public async Task<(Product producto, string status)> UpdateProductAsync(int id, Product updatedProduct)
        {
            var response = await _httpClient.PutAsJsonAsync($"products/{id}", updatedProduct);
            string statusMsg = $"{(int)response.StatusCode} {response.ReasonPhrase}";

            if (response.IsSuccessStatusCode)
            {
                var producto = await response.Content.ReadFromJsonAsync<Product>();
                return (producto, statusMsg);
            }
            return (null, statusMsg);
        }

        public async Task<(bool exito, string status)> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            string statusMsg = $"{(int)response.StatusCode} {response.ReasonPhrase}";
            return (response.IsSuccessStatusCode, statusMsg);
        }
    }
}