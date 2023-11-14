using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConcurrency.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public long Id { get; set; }

        public int Gold { get; set; }


        public DateTime LastUpdated { get; set; }
    }
}
