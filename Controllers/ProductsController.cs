using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;

namespace Controllers
{
    [Produces("application/json")]
    [Route("api/prod")]
    public class ProductsController
    {
        Products[] products = new Products[]
        {
            new Products {Code = "1", Description = "Rice",  NetWeight = 1, Price = 50 },
            new Products {Code = "2", Description = "PASTA",  NetWeight = 0.5, Price = 55 },
            new Products {Code = "3", Description = "Bread",  NetWeight = 0.3, Price = 40 },
            new Products {Code = "4", Description = "Chocolate", NetWeight = 0.4, Price = 95 }
        };

        [HttpGet]
        public IEnumerable<Products> ListAllProducts()
        {
            return products;
        }

        [HttpGet("code/{codart}")]
        public IEnumerable<Products> ListProductsByCode(string codart)
        {
             IEnumerable<Products> retVal =
                from g in products 
                where g.Code.Equals(codart) 
                select g;

            return retVal;

        }

        [HttpGet("description/{desart}")]
        public IEnumerable<Products> ListProductsByDescription(string desart)
        {
            IEnumerable<Products> retVal = 
                from g in products
                where g.Description.ToUpper().Contains(desart.ToUpper())
                orderby g.Code
                select g;
                
            return retVal;
            
        }
    }
}