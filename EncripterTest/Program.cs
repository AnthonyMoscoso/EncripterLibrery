using Business.EncryptServices.Algorithms;
using Core.Entities.Utilities.Encrypt;
using EncripterTest.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EncripterTest
{
    class Program
    {
        static void Main(string[] args)
        {


            Users users = new Users()
            {
                Name = "TEST",
                Email = "Test@gmail.com",
                Pass = "Pass12345",
                Phone = "+34 6578585885"
            };


            IEncrypt encrypt = new EncryptBase64();

            UsersEncrypterProfile _encrypter = new UsersEncrypterProfile(encrypt);

            Console.WriteLine("User Print");
            Console.WriteLine(users.ToString());
            Users encrypter = _encrypter.EncryptEntity(users);
            Console.WriteLine("----- User Encrypter ----\n\n");
            Console.WriteLine(encrypter.ToString());
            Console.WriteLine("----- User Descrypter ----\n\n");
            Console.WriteLine(_encrypter.DecryptEntity(encrypter).ToString());
        }
    }
}
