using System;
using System.Collections.Generic;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class Team : BaseEntity
    {
        public Team()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool ApplyScheduleAccessRule { get; set; }
        public Team TeamLeader { get; set; }
        public Entity Entity { get; set; }
        public ICollection<EmosUser> Users { get; set; }
    }
}
