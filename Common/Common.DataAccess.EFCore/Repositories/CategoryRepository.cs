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
    public class CategoryRepository : BaseRepository<Category, DataContext>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }

        public override async Task<Category> Get(Guid id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Categories
                .Where(obj => obj.Id == id && !obj.IsDelete)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> Get(ContextSession session)
        {
            var context = GetContext(session);
            return await context.Categories
                .Where(obj => !obj.IsDelete && obj.UserId == session.UserId)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<bool> Exists(Category obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Categories
                .Where(x => x.Id == obj.Id && !x.IsDelete)
                .AsNoTracking()
                .CountAsync() > 0;
        }
    }
}