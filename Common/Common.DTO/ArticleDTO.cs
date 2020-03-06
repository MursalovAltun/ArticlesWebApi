using System;

namespace Common.DTO
{
    public class ArticleDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }

        public UserDTO User { get; set; }

        public CategoryDTO Category { get; set; }
    }
}