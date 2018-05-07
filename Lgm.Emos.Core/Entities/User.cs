using System;
using System.Collections.Generic;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Service { get; set; }
        public string Office { get; set; }
        public string Team { get; set; }
        public string Rank { get; set; }
        public string BadgeCode { get; set; }



    }
}
