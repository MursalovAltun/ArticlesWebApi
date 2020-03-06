using System;

namespace Common.DTO
{
    public class ArticleCategoryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifyDate { get; set; }
    }
}