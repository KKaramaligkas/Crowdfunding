using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class ProjectCreator
    {
        public ProjectCreator()
        {
            Projects = new HashSet<Projects>();
        }

        public int ProjectCreatorId { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
        public ICollection<Projects> Projects { get; set; }
    }
}
