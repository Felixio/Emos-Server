using System;
using System.Collections.Generic;
using System.Text;


namespace Lgm.Emos.Core.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {

        }
        public int EntityId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Entity Entity { get; set; }
    }
}
