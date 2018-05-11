using System;
using System.Collections.Generic;
using System.Text;

namespace Lgm.Emos.Core.Entities
{
    public class Card : BaseEntity
    {
        protected Card()
        {
        }

        public string Number { get; set; }
        public string AdditionalInfo  { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateExpiration { get; set; }
        public bool IsActive { get; set; }
        public int CardTypeId { get; set; }

    }
}
