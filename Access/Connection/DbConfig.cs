using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.Connection
{
    public class DbConfig : DbConfiguration
    {
        public DbConfig()
        {
            //SetProviderFactory("Npgsql", Npgsql.NpgsqlFactory.Instance);
            //SetProviderServices("Npgsql", provider: NpgsqlServices.Instance);
            //SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
        }
    }
}
