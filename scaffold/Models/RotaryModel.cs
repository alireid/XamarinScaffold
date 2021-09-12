using System;
using System.Collections.Generic;
using System.Text;

namespace scaffold.Models
{
    public class RotaryModel
    {
        public List<RotarySector> Sectors { get; set; }

    }
    public class RotarySector
    {
        public string Sign { get; set; }
        public string Color { get; set; }
    }
}