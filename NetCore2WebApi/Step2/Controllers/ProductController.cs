using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Step2.Dto;
using Step2.Services;

namespace Step2.Controllers
{
    //[Route("api/product")]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductService.Current.Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = ProductService.Current.Products?.SingleOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductCreation product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var maxId = ProductService.Current.Products.Max(i => i.Id);
            var newProduct = new Product
            {
                Id = ++maxId,
                Name = product.Name,
                Price = product.Price
            };

            ProductService.Current.Products.Add(newProduct);

            return CreatedAtAction("GetProduct", new { id = newProduct.Id }, newProduct);
            //return Ok();
        }

        // Materials 方法
        [HttpGet("{productId}/materials")]
        public IActionResult GetMaterials(int productId)
        {
            var product = ProductService.Current.Products?.SingleOrDefault(x => x.Id == productId);

            if (product == null || product?.Materials == null)
            {
                return NotFound();
            }

            return Ok(product.Materials);
        }

        [HttpGet("{productId}/materials/{id}")]
        public IActionResult GetMaterial(int productId, int id)
        {
            var product = ProductService.Current.Products.SingleOrDefault(x => x.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            var material = product.Materials.SingleOrDefault(x => x.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }
    }
}