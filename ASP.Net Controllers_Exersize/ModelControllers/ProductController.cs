using ASP.Net_Controllers_Exersize.Context;
using ASP.Net_Controllers_Exersize.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Controllers_Exersize.ModelControllers
{
    [Route("api/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly AppDBContext _appDB;
        public ProductController(AppDBContext appDB)
        {
            _appDB = appDB;
        }

        [HttpPost]
        public ActionResult PostProduct([FromBody] Product product)
        {
            _appDB.Products.Add(product);
            _appDB.SaveChanges();
            return Ok(product);
        }

        [HttpGet]
        public ActionResult<IQueryable<Product>> GetAllProduct([FromQuery] string name = null, [FromQuery] string price=null)
        {
           var products = _appDB.Products.ToList();
            if (name != null)
            {
              products = products.Where(n => n.ProductName.Equals(name)).ToList();
                return Ok(products);
            }

            // String formatidagi number larni sortlash qiyin!!!
            
            return NotFound();
        }

         
        [HttpGet]
        public ActionResult GetProductId([FromQuery]int id)
        {
            var product = _appDB.Products.Find(id);
            if(product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }


        [HttpPut]
        public ActionResult PutProduct([FromQuery]int id, [FromBody] Product newProduct)
        {
            var product = _appDB.Products.Find(id);
            if(product != null)
            {
                product.ProductName = newProduct.ProductName;
                product.ProductPrice = newProduct.ProductPrice;
                _appDB.Products.Update(product);
                _appDB.SaveChanges();  
                return Ok(product);
            }
            return NotFound();
        }



        [HttpDelete]
        public ActionResult DeleteProduct([FromQuery]int id) {
            var product = _appDB.Products.Find(id);
            if (product != null)
            {
                _appDB.Products.Remove(product);
                _appDB.SaveChanges();
                return Ok(product);
            }
            return NotFound();
        }
    }
}
