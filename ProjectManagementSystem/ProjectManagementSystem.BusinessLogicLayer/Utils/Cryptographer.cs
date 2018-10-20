using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Utils
{
    public class Cryptographer
    {
        public static string MD5Hash(string value)
        {

            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(value);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string Base64Encode(string value)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string HMAC_SHA256Encode(string value, string key)
        {
            byte[] bKey = Encoding.Default.GetBytes(key);
            using (var hmac = new HMACSHA256(bKey))
            {
                byte[] bValue = Encoding.Default.GetBytes(value);
                var bHash = hmac.ComputeHash(bValue);
                return BitConverter.ToString(bHash).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
