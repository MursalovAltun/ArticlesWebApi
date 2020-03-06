using System;

namespace Common.DTO
{
    public class ArticleAddDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }
    }
}