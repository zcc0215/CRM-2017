using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB
{
    public class WelcomeEmail : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Info { get; set; }
    }
}
