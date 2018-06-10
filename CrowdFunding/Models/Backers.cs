using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Backers
    {
        public Backers()
        {
            ProjecBacker = new HashSet<ProjecBacker>();
        }

        public int BackerId { get; set; }
        public int UserId { get; set; }
        public decimal Fund { get; set; }

        public Users User { get; set; }
        public ICollection<ProjecBacker> ProjecBacker { get; set; }
    }
}
