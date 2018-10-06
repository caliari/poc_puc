using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Access.Repository;

namespace Bussiness.Class
{
    public class FreteBussiness
    {
        private readonly FreteRepository _repository;

        public int _codigoEmpresa { get; private set; }

        public FreteBussiness()
        {
            _repository = new FreteRepository();
        }

        //public ImovelRural GetbyId(int id)
        //{
        //    return _repository.GetbyId(id);
        //}

        public IEnumerable<Frete> GetAll()
        {
            return _repository.GetAll();
        }

        public Frete Add(Frete obj)
        {
            return _repository.Add(obj);
        }
    }
}
