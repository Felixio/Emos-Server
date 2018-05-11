using System;
using System.Collections.Generic;
using System.Text;


namespace Lgm.Emos.Core.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {

        }

        public int EntityId { get; set; }
        public int EmosUserId { get; set; }
        public EmosUser User { get; set; }
        public Entity Entity { get; set; }
    }
}
