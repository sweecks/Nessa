using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nessa.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Моля въведете име!")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        public ICollection<Image> Images { get; set; }

        [Required(ErrorMessage = "Моля въведете описание!")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Моля въведете цена!")]
        [Display(Name = "Цена")]
        public string Price { get; set; }

        public Category Category { get; set; }

        [Required(ErrorMessage = "Моля изберете категория!")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
    }
}