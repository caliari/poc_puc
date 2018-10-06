using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    [Table("frete")]
    public class Frete
    {
        [Key]
        [Column("id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public double preco { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }
        public string valor { get; set; }
    }
}
