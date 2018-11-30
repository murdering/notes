using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{id}", Name = "GetProduct")]
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

            //简单自定义验证
            if (product.Name == "测试")
            {
                ModelState.AddModelError("Name", "产品名称不能是'测试'");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maxId = ProductService.Current.Products.Max(i => i.Id);
            var newProduct = new Product
            {
                Id = ++maxId,
                Name = product.Name,
                Price = product.Price
            };

            ProductService.Current.Products.Add(newProduct);

            return CreatedAtRoute("GetProduct", new { id = newProduct.Id }, newProduct);
            //return CreatedAtAction("GetProduct", new { id = newProduct.Id }, newProduct);
            //return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductModification product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            //简单自定义验证
            if (product.Name == "测试")
            {
                ModelState.AddModelError("Name", "产品名称不能是'测试'");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = ProductService.Current.Products.SingleOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            model.Name = product.Name;
            model.Price = product.Price;
            model.Description = product.Description;

            return Ok(model);
            //return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<ProductModification> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var model = ProductService.Current.Products.SingleOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            var toPatch = new ProductModification
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description
            };

            patchDoc.ApplyTo(toPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //简单自定义验证
            if (toPatch.Name == "测试")
            {
                ModelState.AddModelError("Name", "产品名称不能是'测试'");
            }

            TryValidateModel(toPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.Name = toPatch.Name;
            model.Price = toPatch.Price;
            model.Description = toPatch.Description;

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = ProductService.Current.Products.SingleOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            ProductService.Current.Products.Remove(model);

            return NoContent();
        }

        // Materials 方法

        #region Materials 方法

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

        #endregion Materials 方法
    }
}