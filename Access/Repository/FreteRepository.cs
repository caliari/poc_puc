using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Npgsql;

namespace Access.Repository
{
    public class FreteRepository
    {
        public FreteRepository()
        {

        }

        public IEnumerable<Frete> GetAll()
        {
            try
            {
                using (var db = new Connection.SigContext())
                {
                    var fretes = db.Fretes.ToList();
                    return fretes;
                }
            }
            catch (Exception ex)
            {
                return null;
            }   
        }

        public Frete Add(Frete obj)
        {
            try
            {
                using (var db = new Connection.SigContext())
                {
                    db.Fretes.Add(obj);
                    db.SaveChanges();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
