using System;
using System.Collections.Generic;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class UserTeam
    {
        public UserTeam()
        {

        }
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public EmosUser User { get; set; }
        public Team Team { get; set; }
    }
}
