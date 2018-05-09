using System;
using System.Collections.Generic;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class Entity 
    {
        public Entity()
        {

        }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Entity ParentEntity { get; set; }
        //To Do : à Replcer Par Picture
        public int idPicture { get; set; }
        public ICollection<User> Users { get; set; }
        
    }
}
