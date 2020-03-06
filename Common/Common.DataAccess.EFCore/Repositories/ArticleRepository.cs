using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using Common.Entities.System;
using Common.Services.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Common.DataAccess.EFCore.Repositories
{
    public class ArticleRepository : BaseRepository<Article, DataContext>, IArticleRepository
    {
        private readonly IHttpContextAccessor _accessor;

        public ArticleRepository(DataContext context, IHttpContextAccessor accessor) : base(context)
        {
            this._accessor = accessor;
        }

        public override async Task<Article> Get(Guid id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Articles
                .Include(x => x.Category)
                .Where(obj => obj.Id == id && !obj.IsDelete)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public override async Task<Article> Edit(Article obj, ContextSession session)
        {
            // TODO: Remove this ugly code in next version
            obj.Link = "holder";
            var article = await base.Edit(obj, session);
            var request = this._accessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host.Value}{request.PathBase.Value}";
            article.Link = $"{baseUrl}/api/Article/{article.Id}";
            return await base.Edit(article, session);
        }

        public async Task<IEnumerable<Article>> Get(ContextSession session)
        {
            var context = GetContext(session);
            return await context.Articles
                .Include(x => x.Category)
                .Where(x => !x.IsDelete)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetByCategory(Guid categoryId, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Articles
                .Include(x => x.Category)
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