using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Progress
    {
        public int ProgressId { get; set; }
        public string CategoryName { get; set; }
        public int ProjectId { get; set; }
    }
}
