using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    [Table("pedido")]
    public class Pedido
    {
        public int id { get; set; }
        public string status { get; set; }
        public string solicitante { get; set; }
        public DateTime? tempo { get; set; }
    }
}
