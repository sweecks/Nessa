using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nessa.Models;
using System.Data.Entity;

namespace Nessa.Controllers.Api
{
    public class ItemsController : ApiController
    {
        private ApplicationDbContext _context;
        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public void DeleteItem(int id)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Items.Remove(item);
            _context.SaveChanges();
        }
    }
}
