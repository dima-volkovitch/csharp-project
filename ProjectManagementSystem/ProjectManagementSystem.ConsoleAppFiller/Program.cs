using Newtonsoft.Json;
using ProjectManagementSystem.BusinessLogicLayer;
using ProjectManagementSystem.BusinessLogicLayer.Token;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.ConsoleAppFiller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = Cryptographer.Base64Encode("my name is DIMA");
            Console.WriteLine(str);
            Console.WriteLine(Cryptographer.Base64Decode(str));

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"key", "value" },

                {"eke", "lol" }
            };

            string json = JsonConvert.SerializeObject(dict);

            Console.WriteLine(json);

            dict =  JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            User u = new User
            {
                FirstName = "Dima"
            };

            string jjj = JsonConvert.SerializeObject(u);
            Console.WriteLine("{\"typ\":\"JWT\",\"alg\":\"HS256\"}");
            u = (User)JsonConvert.DeserializeObject<User>(jjj);
            string i = "{\"Id\":\"1\"}";

            Jwt jwt = new Jwt(new Header(), new Payload());
            jwt.Payload.User = 1;
            Console.WriteLine(JwtWorker.GenerateTokenString(jwt, "123"));

        }
    }
}
