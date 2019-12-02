using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nessa.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public Item Item { get; set; }

        public int ItemId { get; set; }
    }
}