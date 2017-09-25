using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileHW.DataAccess.DBModels
{
    public class Product:BaseEntity
    {
       
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string OriginCountry { get; set; }
        [Required]
        public string SeriaNumber { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
       
    }
}
