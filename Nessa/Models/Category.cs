using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nessa.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Моля въведете име!")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Изображение")]
        public string ImagePath { get; set; }

        public string Title
        {
            get
            {
                if (this.Id != 0)
                {
                    return "Редактирай категорията";
                }

                return "Нова категория";
            }
        }
    }
}