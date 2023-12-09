using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; } = 0;
        public int Amount { get; set; } = 0;
        public decimal Price { get; set; }
        public virtual ICollection<ProductPhotos> Photos { get; set; } = new HashSet<ProductPhotos>();

    }
}
