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
        public CurrentFavouriteCard CurrentFavouriteCard { get; set; }
        public int Wins { get; set; }
        public int ThreeCrownWins { get; set; }
        public int Losses { get; set; }
        public int BestTrophies { get; set; }
        public int TotalDonations { get; set; }


    }

    public class Arena
    {
        public string Name { get; set; }
    }

    public class Clan
    {
        public string Name { get; set; }
    }

    public class CurrentFavouriteCard
    {
        public string Name { get; set; }
    }
}
