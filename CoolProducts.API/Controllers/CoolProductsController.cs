using CoolProducts.API.Models.Data;
using CoolProducts.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace CoolProducts.API.Controllers
{
    [RoutePrefix("api/coolproducts")]
    public class CoolProductsController : ApiController
    {
        // DI
        CoolProductsDbContext db = new CoolProductsDbContext();

        // Design the URI - End point
        // MVC ...../CoolProducts/List   = MVC return all products with view

        //public ActionResult List()
        //{
        //    return View(data);
        //}


        // HttpGET ...api/CoolProducts = return all products without view
        //[HttpGet]
  [EnableQuery]
      [Authorize]
        public IQueryable<Product> GetProducts()
        {
            // fetch data from model and return
            return db.Products.AsQueryable();

        }

        // Tools for debugging api
        // any web browser - GET
        // postman
        // fidler
        // swagger
        // visual studio code


        // Design the End Point
        // GET api/coolproducts/id

        public IHttpActionResult GetProduct(int id)
        {
            var p = db.Products.Find(id);
            if (p == null)
            {
                // return http status code 404
                return NotFound();
            }

            // return data with http status code 200
            return Ok(p);
        }


        // Lab 1: get all products by name
        // GET /api/coolproducts/pname/iphone
        [HttpGet]
        [Route("name/{name}")]
        public IHttpActionResult GetProductByName(string name)
        {
            var products = db.Products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            if (products == null || products.Count == 0)
                return NotFound();
            return Ok(products);
        }

        // Lab 2: get all products by brand
        // api/coolproducts/brand/apple
        [Route("brand/{brand}")]
        public IHttpActionResult GetProductsByBrand(string brand)
        {
            var products = db.Products.Where(p => p.Brand.ToLower().Contains(brand.ToLower())).ToList();
            if (products == null || products.Count == 0)
                return NotFound();
            return Ok(products);
        }
        //// Lab 3: get all producgs by category
        [Route("category/{cat}")]
        public IHttpActionResult GetProductsByCategory(string cat)
        {
            var products = db.Products.Where(p => p.Category.ToLower().Contains(cat.ToLower())).ToList();
            if (products == null || products.Count == 0)
                return NotFound();
            return Ok(products);
        }
        //// Lab 4: get costliest product
        //// GET api/coolproducts/costliest
        [Route("costliest")]
        public IHttpActionResult GetCostliestProduct()
        {
            return Ok(db.Products.OrderByDescending(p => p.Cost).FirstOrDefault());
        }
        //// Lab 5: get cheapest product
        [Route("cheapest")]
        public IHttpActionResult GetCheapestProduct()
        {
            return Ok(db.Products.OrderBy(p => p.Cost).FirstOrDefault());
        }
        //// Lab 6: get products between min and max cost
        [Route("costbetween/min/{min}/max/{max}")]
        public IHttpActionResult GetProducsCostRange(int min, int max)
        {
            var products = from p in db.Products
                           where p.Cost >= min && p.Cost <= max
                           select p;
            if (products == null || products.Count() == 0)
            {
                return NotFound();
            }

            return Ok(products.ToList());
        }
        // ToDo
        // desing the end points URI
        // implement the action method
        // take care of http status codes

        // DELETE api/coolproudcts/id
        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var p = db.Products.Find(id);
            if (p == null)
                return NotFound();
            db.Products.Remove(p);
            db.SaveChanges();
            return Ok();
        }

        //  PUT api/coolproducts/id
        [HttpPut]
        public IHttpActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(product);
        }

        // POST api/coolproducts
        [HttpPost]
        public IHttpActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");
            db.Products.Add(product);
            db.SaveChanges();
            // return status code (201) + location (uri) + saved data(content)
            return Created($"api/coolproudcts/{product.ProductId}", product);
        }
    }
}
