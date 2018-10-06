using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.Repository
{
    public class PedidoRepository
    {
        public PedidoRepository()
        {

        }

        public IEnumerable<Pedido> GetAll()
        {
            try
            {
                using (var db = new Connection.SigContext())
                {
                    var pedidos = db.Pedidos.ToList();
                    return pedidos;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
