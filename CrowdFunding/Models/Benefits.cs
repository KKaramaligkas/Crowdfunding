using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Benefits
    {
        public int BenefitsId { get; set; }
        public string BenefitName { get; set; }
        public int ProjectId { get; set; }

        public Projects Project { get; set; }
    }
}
