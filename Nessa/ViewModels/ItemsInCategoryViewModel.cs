using Nessa.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nessa.ViewModels
{
    public class ItemsInCategoryViewModel
    {
        public Category Category { get; set; }

        public IPagedList<Item> Items { get; set; }
    }
}