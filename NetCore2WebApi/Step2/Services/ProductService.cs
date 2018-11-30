using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Step2.Dto;

namespace Step2.Services
{
    public class ProductService
    {
        public static ProductService Current { get; } = new ProductService();

        public List<Product> Products { get; }

        private ProductService()
        {
            Products = new List<Product> {
                new Product
                {
                    Id = 1,
                    Name = "Milk",
                    Price = 3f,
                    Description = "This is milk",
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 1,
                            Name = "Water"
                        },
                        new Material
                        {
                            Id = 2,
                            Name = "Milk Powder"
                        }
                    }
                },
                new Product
                {
                    Id = 2,
                    Name = "Bread",
                    Price = 5f,
                    Description = "This is bread",
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 3,
                            Name = "B Water"
                        },
                        new Material
                        {
                            Id = 4,
                            Name = "Powder"
                        }
                    }
                },
                new Product
                {
                    Id = 3,
                    Name = "Beer",
                    Price = 7.5f,
                    Description = "This is beer",
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 3,
                            Name = "Undergroud Water"
                        },
                        new Material
                        {
                            Id = 4,
                            Name = "Malt"
                        }
                    }
                }
            };
        }
    }
}