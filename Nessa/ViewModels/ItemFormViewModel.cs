using Nessa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nessa.ViewModels
{
    public class ItemFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Item Item { get; set; }

        public string Title
        {
            get
            {
                if (Item != null && Item.Id != 0)
                {
                    return "Редактирай продукта";
                }

                return "Нов продукт";
            }
        }
    }
}