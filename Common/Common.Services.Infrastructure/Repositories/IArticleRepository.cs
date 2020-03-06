using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;
using Common.Entities.System;

namespace Common.Services.Infrastructure.Repositories
{
    public interface IArticleRepository
    {
        Task<Article> Get(Guid id, ContextSession session);

        Task<IEnumerable<Article>> Get(ContextSession session);

        Task<IEnumerable<Article>> GetByCategory(Guid categoryId, ContextSession session);

        Task<Article> Edit(Article article, ContextSession session);

        Task<bool> Exists(Article article, ContextSession session);

        Task Delete(Guid id, ContextSession session);
    }
}