using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tornament.types
{
    internal class User
    {
        public int UserID { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public required string UserPassword { get; set; }
    }
}
