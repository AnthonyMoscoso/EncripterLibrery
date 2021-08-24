using Core.Entities.Utilities.Encrypt;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncripterTest.Profiles
{
    public class UsersEncrypterProfile : BaseEncryterProfile<Users>
    {
        public UsersEncrypterProfile(IEncrypt encrypt) : base(encrypt)
        {
            AddParameter(w => w.Pass);
            AddParameter(w => w.Email);
        }
    }
}
