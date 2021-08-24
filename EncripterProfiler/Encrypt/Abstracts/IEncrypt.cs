using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.Encrypt
{
    public interface IEncrypt
    {
        /// <summary>
        /// Encryp a string value 
        /// </summary>
        /// <param name="value">value to be encrypt</param>
        /// <returns>string encrypt</returns>
        string Encrypt(string value);

        /// <summary>
        /// Descrypt a string value
        /// </summary>
        /// <param name="value">value to be descrypt</param>
        /// <returns>value descrypt</returns>
        string Decrypt(string value);
    }
}
