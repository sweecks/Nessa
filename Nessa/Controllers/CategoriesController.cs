using Nessa.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nessa.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        // GET: Categories
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        public ActionResult New()
        {
            var category = new Category();

            return View("CategoryForm", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Category();

                return View("CategoryForm", viewModel);
            }

            if (category.Id == 0)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var photo = new Image
                    {
                        Path = Path.GetFileName(image.FileName)
                    };

                    image.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Images/"), image.FileName));

                    category.ImagePath = photo.Path;
                }

                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction("Index", "Categories");
            }
            //else
            //{
            //    var itemInDb = _context.Items.Include(i => i.Images).Single(s => s.Id == item.Id);

            //    itemInDb.Name = item.Name;
            //    itemInDb.Description = item.Description;
            //    itemInDb.Price = item.Price;
            //    itemInDb.CategoryId = item.CategoryId;
            //    foreach (var image in images)
            //    {
            //        if (image != null && image.ContentLength > 0)
            //        {
            //            var photo = new Image
            //            {
            //                Path = Path.GetFileName(image.FileName)
            //            };

            //            image.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Images/"), image.FileName));

            //            itemInDb.Images.Add(photo);
            //        }
            //    }
            //    _context.SaveChanges();

            //    return RedirectToAction("Details", "Items", new { id = itemInDb.Id });
            //}
            return RedirectToAction("Index", "Home");
        }
    }
}