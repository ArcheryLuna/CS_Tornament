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
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Player PlayerThree { get; set; }
        public Player PlayerFour { get; set; }
        public Player PlayerFive { get; set; }
        public string TeamName { get; set; }
    }
}
