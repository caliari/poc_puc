using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Access.Repository;
using Model.Models;

namespace Bussiness.Class
{
    public class PedidoBusiness
    {
        private PedidoRepository _repository;

        public PedidoBusiness()
        {
            _repository = new PedidoRepository();
        }

        //public Usuario GetUser(System.Collections.Hashtable parametro)
        //{
        //    return _repository.GetUser(parametro);
        //}

        public IEnumerable<Pedido> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
