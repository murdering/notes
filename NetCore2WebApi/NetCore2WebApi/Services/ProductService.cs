using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore2WebApi.Dto;

namespace NetCore2WebApi.Services
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