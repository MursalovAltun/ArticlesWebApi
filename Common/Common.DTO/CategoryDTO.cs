﻿using System;
using System.Collections.Generic;

namespace Common.DTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public virtual IEnumerable<ArticleDTO> Articles { get; set; }
    }
}