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

        // GET: Obtener productos
        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Product>>("products");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                return new List<Product>();
            }
        }

        // POST: Crear producto
        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("products/", newProduct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        // PUT: Actualizar producto
        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            var response = await _httpClient.PutAsJsonAsync($"products/{id}", updatedProduct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        // DELETE: Eliminar producto
        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}