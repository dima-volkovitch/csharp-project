using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Token
{
    public class JwtWorker
    {
        private const string signatureTemplate = "{0}.{1}";
        private const string tokenTemplate = "{0}.{1}.{2}";

        public static bool IsValidSignature(Jwt jwt, string key)
        {
            string oldSignature = jwt.Signature;
            string newSignature = GenerateSignature(jwt, key);
            return oldSignature.Equals(newSignature);
        }

        public static string GenerateTokenString(Jwt jwt, string key)
        {
            return string.Format(tokenTemplate,
                Cryptographer.Base64Encode(JsonConvert.SerializeObject(jwt.Header)),
                Cryptographer.Base64Encode(JsonConvert.SerializeObject(jwt.Payload)), 
                GenerateSignature(jwt, key));
        }

        public static Jwt DecodeTokenString(string str)
        {
            string[] arr = str.Split('.');
            return new Jwt(JsonConvert.DeserializeObject<Header>(Cryptographer.Base64Decode(arr[0])),
                JsonConvert.DeserializeObject<Payload>(Cryptographer.Base64Decode(arr[1])),
                arr[2]);
            
        }

        private static string GenerateSignature(Jwt jwt, string key)
        {
            string signature = Cryptographer.HMAC_SHA256Encode(string.Format(signatureTemplate,
                Cryptographer.Base64Encode(JsonConvert.SerializeObject(jwt.Header)),
                Cryptographer.Base64Encode(JsonConvert.SerializeObject(jwt.Payload))), key);
            jwt.Signature = signature;
            return signature;
        }
    }
}
