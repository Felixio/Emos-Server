using System;
using System.Collections.Generic;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class Grade: BaseEntity
    {  public Grade()
        {

        }
        public string Name { get; set; }
        public int Rank { get; set; }
        //To Do : Replca Par Pictures
        public int IdPicture { get; set; }
    }
}
