using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace DAL
{

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public class Player
    {

        public string Image { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int GoalsInThisMatch { get; set; }
        public int YellowCardsInThisMatch { get; set; }
        public Player(string name)
        {
            this.Name = name;


        }
        public Player(string name, bool captain, int shirtNumber, string position)
        {
            Name = name;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Position = position;
        }
        public Player(string name, bool captain, int shirtNumber, string position, int yellowcards, int goals)
        {
            Name = name;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Position = position;
            YellowCardsInThisMatch = yellowcards;
            GoalsInThisMatch = goals;
        }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

