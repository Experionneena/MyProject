using System;

namespace RI.Framework.Core.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime? CreatedDate { get; set; }

        DateTime? EditedDate { get; set; }
    }
}
