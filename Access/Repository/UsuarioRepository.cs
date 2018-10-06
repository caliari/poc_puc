using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uitl;

namespace Access.Repository
{
    public class UsuarioRepository
    {
        public UsuarioRepository()
        {

        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                using (var db = new Connection.SigContext())
                {
                    var usuarios = db.Usuarios.ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Usuario GetUser(System.Collections.Hashtable parametro)
        {
            try
            {
                var senhaCrypt = Cryptography.Generate(parametro["email"].ToString(), parametro["senha"].ToString());
                var email = parametro["email"].ToString();
                using (var db = new Connection.SigContext())
                {
                    var usuarios = db.Usuarios.FirstOrDefault(x => x.email == email && x.senha == senhaCrypt);
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
