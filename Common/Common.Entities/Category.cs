using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}