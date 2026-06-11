using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorHybridTP4.Models;

namespace BlazorHybridTP4.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public int CategoryId { get; set; }
    }
}
