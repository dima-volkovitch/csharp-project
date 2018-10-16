using ProjectManagementSystem.BusinessLogicLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer
{
    internal class TokenDictionary
    {
        private static TokenDictionary dictionary;

        private Dictionary<string, long> dict;

        private TokenDictionary()
        {
            dict = new Dictionary<string, long>();
        }

        public static TokenDictionary Dictionary
        {
            get
            {
                if (dictionary == null)
                {
                    dictionary = new TokenDictionary();
                }
                return dictionary;
            }
        }

        public void Add(string token, long id)
        {
            try
            {
                dict.Add(token, id);
            }
            catch (ArgumentException e)
            {
                throw new UserAlreadyAuthorizedException(e.Message, e);
            }
        }

        public long this[string token]
        {
            get
            {
                return dict[token];
            }
            set
            {
                dict[token] = value;
            }
        }

        public bool Remove(string token)
        {
            return dict.Remove(token);  
        }

        public bool ContainsToken(string token)
        {
            return dict.ContainsKey(token);
        }
    }
}
