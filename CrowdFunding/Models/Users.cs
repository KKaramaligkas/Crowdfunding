using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Users
    {
        public Users()
        {
            Backers = new HashSet<Backers>();
            ProjectCreator = new HashSet<ProjectCreator>();
        }

        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mobilephone { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }

        public ICollection<Backers> Backers { get; set; }
        public ICollection<ProjectCreator> ProjectCreator { get; set; }
    }
}
