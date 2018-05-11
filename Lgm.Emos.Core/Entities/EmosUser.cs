using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class EmosUser : BaseEntity
    {
        public EmosUser()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardCode { get; set; }      
        public string Number { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityId { get; set; }
        public IdentityAppUser Identity { get; set; }
        public ApplicationGroup Group { get; set; }
        public Grade Grade { get; set; }
        public Function Function { get; set; }
        public Card Card { get; set; }
        // TODO : Add Picture
        public ICollection<UserEntity> UserEntities { get; set; }
        public ICollection<UserTeam> UserTeams { get; set; }



    }
}
