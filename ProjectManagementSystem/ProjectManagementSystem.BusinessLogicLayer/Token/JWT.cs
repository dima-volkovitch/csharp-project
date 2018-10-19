using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Token
{
    public class Jwt
    {
        public Header Header { get; set; }

        public Payload Payload { get; set; }

        public string Signature { get; set; }

        public Jwt()
        {

        }

        public Jwt(Header header)
        {
            Header = header;
        }

        public Jwt(Header header, Payload payload)
        {
            Header = header;
            Payload = payload;
        }

        public Jwt(Header header, Payload payload, string signature)
        {
            Header = header;
            Payload = payload;
            Signature = signature;
        }
    }
}
