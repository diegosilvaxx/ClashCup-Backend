using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.DTO
{
    public class ClashRoyaleRankingDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public string Tag { get; set; }
        public List<MembersList> MembersList { get; set; }

    }

    public class MembersList
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
        public string Tag { get; set; }

    }

}
