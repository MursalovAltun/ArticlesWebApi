using System;

namespace Common.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Category Category { get; set; }
    }
}