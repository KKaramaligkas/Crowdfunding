using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Projects
    {
        public Projects()
        {
            Benefits = new HashSet<Benefits>();
            ProjecBacker = new HashSet<ProjecBacker>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public decimal AskedFund { get; set; }
        public int Days { get; set; }
        public int ProjectCreatorId { get; set; }
        public byte NumberOfBenefits { get; set; }
        public int CategoryId { get; set; }

        public Categories Category { get; set; }
        public ProjectCreator ProjectCreator { get; set; }
        public ICollection<Benefits> Benefits { get; set; }
        public ICollection<ProjecBacker> ProjecBacker { get; set; }
    }
}
