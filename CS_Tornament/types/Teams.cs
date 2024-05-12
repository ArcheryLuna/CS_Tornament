using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tornament.types
{
    internal class Teams
    {
        public int TeamId { get; set; }
        public required Player PlayerOne { get; set; }
        public required Player PlayerTwo { get; set; }
        public required Player PlayerThree { get; set; }
        public required Player PlayerFour { get; set; }
        public required Player PlayerFive { get; set; }
        public required string TeamName { get; set; }
    }
}
