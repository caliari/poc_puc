using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uitl
{
    public static class Cryptography
    {
        public static string Generate(string email, string passoword)
        {
            var bytes = new UTF8Encoding().GetBytes(email + passoword);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}
