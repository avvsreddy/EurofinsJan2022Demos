using CoolProducts.API.Models.Data;
using CoolProducts.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoolProducts.API.Controllers
{
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
        public List<Product> GetProducts()
        {
            // fetch data from model and return
            return db.Products.ToList();

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
            if(p == null)
            {
                // return http status code 404
                return NotFound(); 
            }

            // return data with http status code 200
            return Ok(p);
        }


        // Lab 1: get all products by name
        // Lab 2: get all products by brand
        // Lab 3: get all producgs by category
        // Lab 4: get costliest product
        // Lab 5: get cheapest product
        // Lab 6: get products between min and max cost
        
        // ToDo
        // desing the end poing URI
        // implement the action method
        // take care of http status codes





    }
}
