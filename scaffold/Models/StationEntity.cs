using System;
using System.Collections.Generic;

namespace scaffold.Models
{
    public class StationEntity
    {
        public class Station
        {
            public string name { get; set; }
            public string time { get; set; }
        }

        public class StationPayload
        {
            public string product { get; set; }
            public double version { get; set; }
            public DateTime releaseDate { get; set; }
            public bool demo { get; set; }
            public IList<Station> stations { get; set; }
        }
    }
}


