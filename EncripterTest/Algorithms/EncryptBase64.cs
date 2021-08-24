using Core.Entities.Utilities.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EncryptServices.Algorithms
{
    public class EncryptBase64 : IEncrypt
    {
        public string Decrypt(string value)
        {
            byte[] b = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(b);
        }

        public string Encrypt(string value)
        {
            byte[] vs = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(vs);
        }
    }
}
