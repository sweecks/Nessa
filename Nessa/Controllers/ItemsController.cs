using Nessa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Nessa.ViewModels;
using System.IO;
using PagedList;
using PagedList.Mvc;

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

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var item = _context.Items.Include(i => i.Category).Include(i => i.Images).SingleOrDefault(i => i.Id == id);

            return View(item);
        }

        [AllowAnonymous]
        public ActionResult ItemsInCategory(int id, string search, int? page)
        {
            if (search == null)
            {
                var viewModel = new ItemsInCategoryViewModel
                { 
                    Category = _context.Categories.SingleOrDefault(c => c.Id == id),
                    Items = _context.Items
                    .Include(i => i.Category).Include(i => i.Images)
                    .Where(i => i.CategoryId == id)
                    .ToList().ToPagedList(page ?? 1, 16)
                };

                return View(viewModel);
            }
            else
            {
                var viewModel = new ItemsInCategoryViewModel
                {
                    Category = _context.Categories.SingleOrDefault(c => c.Id == id),
                    Items = _context.Items
                     .Include(i => i.Category).Include(i => i.Images)
                     .Where(i => i.CategoryId == id && i.Name.Contains(search))
                     .ToList().ToPagedList(page ?? 1, 16)
                };

                 return View(viewModel);
            }
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
                _context.SaveChanges();

                return RedirectToAction("ItemsInCategory", "Items", new { id = item.CategoryId });
            }
            else
            {
                var itemInDb = _context.Items.Include(i => i.Images).Single(s => s.Id == item.Id);

                itemInDb.Name = item.Name;
                itemInDb.Description = item.Description;
                itemInDb.Price = item.Price;
                itemInDb.CategoryId = item.CategoryId;
                foreach (var image in images)
                {
                    if (image != null && image.ContentLength > 0)
                    {
                        var photo = new Image
                        {
                            Path = Path.GetFileName(image.FileName)
                        };

                        image.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Images/"), image.FileName));

                        itemInDb.Images.Add(photo);
                    }
                }
                _context.SaveChanges();

                return RedirectToAction("ItemsInCategory", "Items", new { id = item.CategoryId });
            }
        }
    }
}