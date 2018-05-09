using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class User 
    {
        public User()
        {

        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardCode { get; set; }      
        public string Number { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ApplicationGroup Group { get; set; }
        public Grade Grade { get; set; }
        public Function Function { get; set; }
        public Card Card { get; set; }
        //To Do : Replca Par Picture
        public int IdPicture { get; set; }
        public ICollection<Entity> Entities { get; set; }
        public ICollection<Team> Teams { get; set; }



    }
}
