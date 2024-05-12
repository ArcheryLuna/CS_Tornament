using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tornament.types
{
    internal class Player
    {
        public int PlayerID { get; set; }
        public required string PlayerFirstName { get; set; }
        public required string PlayerLastName { get; set; }
        public bool PlayerIsIndividual { get; set; }

    }
}
