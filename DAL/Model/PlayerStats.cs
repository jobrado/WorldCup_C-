using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class PlayerStats
    {
        public string Name { get; set; }
        public int Goals { get; set; }
        public int YellowCard { get; set; }

        public PlayerStats(string name, int goals, int yellowCard)
        {
            Name = name;
            Goals = goals;
            YellowCard = yellowCard;
        }
    }
}
