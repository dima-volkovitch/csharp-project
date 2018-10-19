using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Token
{
    public class Payload
    {
        private const string iss = "dima-volkovitch";
        private const string sub = "authentication";

        public string Iss { get; set; } = iss;

        public string Sub { get; set; } = sub;

        public long User { get; set; } = 0;
    }
}
