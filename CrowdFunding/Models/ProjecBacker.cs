using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class ProjecBacker
    {
        public int ProjectId { get; set; }
        public int BackerId { get; set; }

        public Backers Backer { get; set; }
        public Projects Project { get; set; }
    }
}
