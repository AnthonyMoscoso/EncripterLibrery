using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.Encrypt
{
    public interface IEncrypterProfile<T> 
    {
        /// <summary>
        /// Descrypt a entity
        /// </summary>
        /// <param name="entity"> the entity to be descrypt </param>
        /// <returns>same entity descrypt</returns>
        T DecryptEntity(T entity);

        /// <summary>
        /// Encrypt entity
        /// </summary>
        /// <param name="entity">the entity yo be encrypt</param>
        /// <returns>same entity encrypt</returns>
        T EncryptEntity(T entity);

        /// <summary>
        /// Descrypt a list of entities
        /// </summary>
        /// <param name="list">list to be descrypt</param>
        /// <returns>same entity descrypt</returns>
        IEnumerable<T> DecryptRange(IEnumerable<T> list);

        /// <summary>
        /// Encrypt a list of entities
        /// </summary>
        /// <param name="list">list to be encrypt</param>
        /// <returns>same entity encrypt</returns>
        IEnumerable<T> EncryptList(IEnumerable<T> list);
    }
}
