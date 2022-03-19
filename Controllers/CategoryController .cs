using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models.Dto;
using WebService.Models.Orm;

namespace WebService.Controllers
{
    public class CategoryController : ApiController
    {

        NorthwindEntities db = new NorthwindEntities();

        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> catList = db.Categories.Select(x => new CategoryModel()
            {
                KategoriAdi = x.CategoryName,
                Aciklamasi = x.Description

            }).ToList();

            return catList;
        }

        [HttpGet]
        public CategoryModel CategoryByID(int id)
        {
            Categories cat = db.Categories.Find(id);
            CategoryModel catModel = new CategoryModel();
            catModel.Aciklamasi = cat.Description;
            catModel.KategoriAdi = cat.CategoryName;

            return catModel;
        }

        [HttpPost]
        public IHttpActionResult AddCategory(CategoryModel _model)
        {
            Categories cat = new Categories()
            {
                CategoryName = _model.KategoriAdi,
                Description = _model.Aciklamasi
            };
            db.Categories.Add(cat);
            db.SaveChanges();
            return Ok();
        }

        /*
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }*/
    }
}