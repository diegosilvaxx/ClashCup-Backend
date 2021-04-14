using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.DTO
{
    public class ClashRoyaleDto
    {
        public string Name { get; set; }
        public string Trophies { get; set; }
        public Arena Arena { get; set; }
        public Clan Clan { get; set; }


    }

    public class Arena
    {
        public string Name { get; set; }
    }

    public class Clan
    {
        public string Name { get; set; }
    }
}
