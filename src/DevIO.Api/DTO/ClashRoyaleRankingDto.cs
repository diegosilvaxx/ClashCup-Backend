using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.DTO
{
    public class ClashRoyaleRankingDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public string Tag { get; set; }
        public MembersList MembersList { get; set; }

    }

    public class MembersList
    {
        public string Name { get; set; }
        public string Score { get; set; }
        public string Rank { get; set; }
        public string Tag { get; set; }
    }
}
