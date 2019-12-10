using Nessa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nessa.Controllers.Api
{
    public class ImagesController : ApiController
    {
        private ApplicationDbContext _context;
        public ImagesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public void DeleteImages(int id)
        {
            var image = _context.Images.SingleOrDefault(i => i.Id == id);

            if (image == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Images.Remove(image);
            _context.SaveChanges();
        }
    }
}
