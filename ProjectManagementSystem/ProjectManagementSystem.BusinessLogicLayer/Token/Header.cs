using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Token
{
    public class Header
    {
        private const string typ = "JWT";
        private const string alg = "HS256";

        public string Typ { get; set; } = typ;

        public string Alg { get; set; } = alg;
    }
}
