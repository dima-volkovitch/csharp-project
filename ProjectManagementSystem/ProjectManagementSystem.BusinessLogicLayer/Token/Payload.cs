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
        private const double lifeTime = 30.0;

        public Payload()
        {
            DateTime now = DateTime.Now;
            CreateDate = now;
            DeathDate = now.AddDays(lifeTime);
        }

        public string Iss { get; set; } = iss;

        public string Sub { get; set; } = sub;

        public long User { get; set; } = 0;

        public DateTime CreateDate { get; set; }

        public DateTime DeathDate { get; set; }
    }
}
