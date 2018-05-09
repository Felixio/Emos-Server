using System;
using System.Collections.Generic;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class UserTeam : BaseEntity
    {
        public UserTeam()
        {

        }
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
