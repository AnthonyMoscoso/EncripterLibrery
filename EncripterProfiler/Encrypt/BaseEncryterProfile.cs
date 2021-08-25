using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Core.Entities.Utilities.Encrypt
{
    public abstract class BaseEncryterProfile<T> : IEncrypterProfile<T>
        where T : class,new()
    {
        private readonly IEncrypt _encrypt;
        private readonly string _name;

        private PropertyInfo[] _properties;
        private readonly ICollection<string> parameters;

        public BaseEncryterProfile(IEncrypt encrypt)
        {
            parameters = new List<string>();
            _encrypt = encrypt;

            _name = typeof(T).Name;
            _properties = typeof(T).GetProperties();
        }

        /// <summary>
        /// Add a parameter to encrypt
        /// </summary>
        /// <param name="parameter">the name of property in the entity</param>
        public void AddParameter<TProperty>(Expression< Func<T, TProperty>> expression) 
        {
            if (typeof(TProperty).Name.ToUpper().Equals("STRING"))
            {
                MemberExpression expressions = expression.Body as MemberExpression;
                string name = expressions.Member.Name;
                if (!parameters.Contains(name))
                {
                    parameters.Add(name);
                }
            }
            else
            {
                throw new Exception("only string value can be encripter");
            }
        }

     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T DecryptEntity(T entity)
        {
            if (entity!= null)
            {
                if (parameters.Count > 0)
                {
                    foreach (string parameter in parameters)
                    {
                        PropertyInfo property = typeof(T).GetProperty(parameter);
                        if (property != null)
                        {
                            Type propertyType = typeof(T).GetProperty(parameter).PropertyType;
                            if (property.GetValue(entity) != null)
                            {
                                property.SetValue(entity, Convert.ChangeType(_encrypt.Decrypt(property.GetValue(entity) as string), propertyType), null);
                            }

                        }
                        else
                        {
                            throw new Exception($"parameter {parameter} not was found in {_name}");
                        }
                    }
                }
            }
  
            return entity;
        }

        /// <summary>
        /// Return the same 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public IEnumerable<T> DecryptRange(IEnumerable<T> list)
        {
            foreach (T entity in list)
            {
                yield return DecryptEntity(entity);
            }
        }

        /// <summary>
        /// Return the same entity Encrypt
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T EncryptEntity(T entity)
        {
            Type type = entity.GetType();
            if (parameters.Count > 0)
            {
                foreach (string parameter in parameters)
                {
                    PropertyInfo property = type.GetProperty(parameter);
                    if (property != null )
                    {
                        if (property.GetValue(entity)!= null)
                        {
                            property.SetValue(entity, _encrypt.Encrypt(property.GetValue(entity) as string), null);
                        }
                    
                    }
                    else
                    {
                        throw new Exception($"parameter {parameter} not was found in {_name}");
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// Return the same list Encrypt
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public IEnumerable<T> EncryptList(IEnumerable<T> list)
        {
            foreach (T entity in list)
            {
                yield return EncryptEntity(entity);
            }
        }
    }
}
