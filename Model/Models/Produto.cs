using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    [Table("produto")]
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
    }
}
