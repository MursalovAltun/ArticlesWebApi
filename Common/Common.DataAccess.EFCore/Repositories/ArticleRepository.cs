using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using Common.Entities.System;
using Common.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Common.DataAccess.EFCore.Repositories
{
    public class ArticleRepository : BaseRepository<Article, DataContext>, IArticleRepository
    {
        public ArticleRepository(DataContext context) : base(context)
        {
        }

        public override async Task<Article> Get(Guid id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Articles
                .Where(obj => obj.Id == id && !obj.IsDelete)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Article>> Get(ContextSession session)
        {
            var context = GetContext(session);
            return await context.Articles.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetByCategory(Guid categoryId, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Articles
                .Where(obj => obj.CategoryId == categoryId && !obj.IsDelete)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<bool> Exists(Article obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Articles
                .Where(x => x.Id == obj.Id && !x.IsDelete)
                .AsNoTracking()
                .CountAsync() > 0;
        }
    }
}