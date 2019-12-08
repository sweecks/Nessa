using Nessa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Nessa.ViewModels;
using System.IO;

namespace Nessa.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ItemsController : Controller
    {
        private ApplicationDbContext _context;
        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Items
        [AllowAnonymous]
        public ActionResult Index()
        {
            var items = _context.Items.OrderBy(i => i.CategoryId).ToList();

            return View(items);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var item = _context.Items.Include(i => i.Category).Include(i => i.Images).SingleOrDefault(i => i.Id == id);

            return View(item);
        }

        [AllowAnonymous]
        public ActionResult ItemsInCategory(int id)
        {
            var items = _context.Items.Include(i => i.Category).Include(i => i.Images).Where(i => i.CategoryId == id).ToList();

            return View(items);
        }

        public ActionResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new ItemFormViewModel
            {
                Item = new Item(),
                Categories = categories
            };

            return View("ItemForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ItemFormViewModel
            {
                Categories = _context.Categories.ToList(),
                Item = item
            };

            return View("ItemForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Item item, IEnumerable<HttpPostedFileBase> images)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ItemFormViewModel
                {
                    Item = item,
                    Categories = _context.Categories.ToList()
                };

                return View("ItemForm", viewModel);
            }

            if (item.Id == 0)
            {
                item.Images = new List<Image>();

                foreach (var image in images)
                {
                    if (image != null && image.ContentLength > 0)
                    {
                        var photo = new Image
                        {
                            Path = Path.GetFileName(image.FileName)
                        };

                        image.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Images/"), image.FileName));

                        item.Images.Add(photo);
                    }
                }

                _context.Items.Add(item);
            }
            else
            {
                var itemInDb = _context.Items.Single(s => s.Id == item.Id);

                itemInDb.Name = item.Name;
                itemInDb.Description = item.Description;
                itemInDb.Price = item.Price;
                itemInDb.CategoryId = item.CategoryId;
            }

            _context.SaveChanges();

            return RedirectToAction("ItemsInCategory", "Items", new { id = item.CategoryId });
        }

        //public ActionResult Remove(int id)
        //{
        //    var item = _context.Items.SingleOrDefault(i => i.Id == id);

        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    _context.Items.Remove(item);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index", "Categories");
        //}
    }
}