using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DTO;
using Common.Entities.System;

namespace Common.Services.Infrastructure.Services
{
    public interface IArticleService
    {
        Task<ArticleDTO> Edit(ArticleAddDTO dto);

        Task<ArticleDTO> GetById(Guid id);

        Task<IEnumerable<ArticleDTO>> Get();

        Task<IEnumerable<ArticleDTO>> GetByCategory(Guid categoryId);

        Task<bool> Exists(Guid id);

        Task<bool> Delete(Guid id);
    }
}