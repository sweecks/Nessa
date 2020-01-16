using Nessa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nessa.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public void DeleteCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
