using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileHW.DataAccess.DBModels
{
    public class BaseEntity
    {
        public int ID { get; set; }
         [Required]
        public DateTime CreatedDate { get; set; }
    }
}
