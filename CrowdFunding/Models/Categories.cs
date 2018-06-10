using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Projects = new HashSet<Projects>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Projects> Projects { get; set; }
    }
}
