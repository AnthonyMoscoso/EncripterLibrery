using Core.Entities.Utilities.Encrypt;
using Microsoft.AspNetCore.DataProtection;
using System;

namespace Business.EncryptServices.Algorithms
{
    public class EncryptProtectionProvider : IEncrypt
    {
        private IDataProtector _protector;
        public EncryptProtectionProvider(IDataProtectionProvider protectionProvider)
        {
            _protector = protectionProvider.CreateProtector("KeysProvider");

        }
        public string Decrypt(string value)
        {
            return _protector.Protect(value);
        }

        public string Encrypt(string value)
        {
            return _protector.Unprotect(value);
        }
    }
}
