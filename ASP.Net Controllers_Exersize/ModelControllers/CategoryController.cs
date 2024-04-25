using ASP.Net_Controllers_Exersize.Context;
using ASP.Net_Controllers_Exersize.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Controllers_Exersize.ModelControllers
{
    [Route("api/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly AppDBContext _appDB;
        public CategoryController(AppDBContext app)
        {
            _appDB = app;
        }

        [HttpPost]
        public ActionResult PostCategory([FromBody] Category categories)
        {
            _appDB.Categories.Add(categories);
            _appDB.SaveChanges();
            return Ok(categories);
        }

        [HttpGet]
        public ActionResult<IQueryable<Category>> GetAllCategories([FromQuery] string name = null)
        {
            var categories = _appDB.Categories;
            if (categories != null)
            {
                categories.OrderBy(name => name.Name);
                _appDB.SaveChanges();
                return Ok(categories);

            }


            if (name != null)
            {
                categories.Where(name => name.Equals(name));
            }
            return NotFound();
        }

        [HttpGet]

        public ActionResult GetCategory(int id)
        {
            var category = _appDB.Categories.Find(id);
            if (category != null)
            {
                _appDB.SaveChanges();
                return Ok(category);
            }
            return NotFound();
        }

        [HttpPut]
        public ActionResult PutCategory([FromQuery] int id, [FromBody] Category categories)
        {
            var category = _appDB.Categories.Find(id);
            if (category != null)
            {
                category.Name = categories.Name;
                _appDB.Categories.Update(category);
                _appDB.SaveChanges();
                return Ok(category);
            }

            return NotFound();
        }



        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            var category = _appDB.Categories.Find(id);
            if (category != null)
            {
                _appDB.Categories.Remove(category);
                _appDB.SaveChanges();
                return Ok(category);
            }
            return NotFound();
        }   
    }
}