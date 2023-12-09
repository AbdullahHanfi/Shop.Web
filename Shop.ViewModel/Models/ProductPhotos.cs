using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class ProductPhotos
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public int ProductId { get; set; }
        public virtual Product product { get; set; }
    }
}
