using System;

namespace RI.Framework.Core.Data.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }          
      
        public DateTime? CreatedDate { get; set; }   
      
        public DateTime? EditedDate { get; set; }
    }
}
