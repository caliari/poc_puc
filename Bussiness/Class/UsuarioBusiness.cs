using Access.Repository;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Class
{
    public class UsuarioBusiness
    {
        private UsuarioRepository _repository;

        public UsuarioBusiness()
        {
            _repository = new UsuarioRepository();
        }

        public Usuario GetUser(System.Collections.Hashtable parametro)
        {
            return _repository.GetUser(parametro);
        }
    }
}
