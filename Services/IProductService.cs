using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorHybridTP4.Models;

namespace BlazorHybridTP4.Services
{
    internal interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> CreateProductAsync(Product newProduct);
        Task<Product> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);
    }
}
