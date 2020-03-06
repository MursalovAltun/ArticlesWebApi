using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;
using Common.Entities.System;

namespace Common.Services.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> Get(Guid id, ContextSession session);

        Task<IEnumerable<Category>> Get(ContextSession session);

        Task<Category> Edit(Category category, ContextSession session);

        Task Delete(Guid id, ContextSession session);

        Task<bool> Exists(Category category, ContextSession session);
    }
}