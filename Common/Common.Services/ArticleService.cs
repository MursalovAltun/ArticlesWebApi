using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.DTO;
using Common.Entities;
using Common.Services.Infrastructure.Repositories;
using Common.Services.Infrastructure.Services;

namespace Common.Services
{
    public class ArticleService : BaseService, IArticleService
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public ArticleService(ICurrentContextProvider contextProvider,
                              IMapper mapper,
                              IArticleRepository articleRepository) : base(contextProvider)
        {
            this._mapper = mapper;
            this._articleRepository = articleRepository;
        }

        public async Task<ArticleDTO> Edit(ArticleAddDTO dto)
        {
            var article = this._mapper.Map<Article>(dto);
            article.UserId = Session.UserId;
            var result = await this._articleRepository.Edit(article, Session);
            return this._mapper.Map<ArticleDTO>(result);
        }

        public async Task<ArticleDTO> GetById(Guid id)
        {
            var result = await this._articleRepository.Get(id, Session);
            return this._mapper.Map<ArticleDTO>(result);
        }

        public async Task<IEnumerable<ArticleDTO>> Get()
        {
            var result = await this._articleRepository.Get(Session);
            return this._mapper.Map<IEnumerable<ArticleDTO>>(result);
        }

        public async Task<IEnumerable<ArticleDTO>> GetByCategory(Guid categoryId)
        {
            var result = await this._articleRepository.GetByCategory(categoryId, Session);
            return this._mapper.Map<IEnumerable<ArticleDTO>>(result);
        }

        public async Task<bool> Exists(Guid id)
        {
            return await this._articleRepository.Exists(new Article {Id = id}, Session);
        }

        public async Task<bool> Delete(Guid id)
        {
            await this._articleRepository.Delete(id, Session);
            return true;
        }
    }
}