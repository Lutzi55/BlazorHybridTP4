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
        Task<(List<Product> productos, string status)> GetProductsAsync();
        Task<(Product producto, string status)> CreateProductAsync(Product newProduct);
        Task<(Product producto, string status)> UpdateProductAsync(int id, Product updatedProduct);
        Task<(bool exito, string status)> DeleteProductAsync(int id);
    }
}
