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
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICurrentContextProvider contextProvider,
                               IMapper mapper,
                               ICategoryRepository categoryRepository) : base(contextProvider)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }

        public async Task<CategoryDTO> GetById(Guid id)
        {
            var category = await this._categoryRepository.Get(id, Session);
            return this._mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            var categories = await this._categoryRepository.Get(Session);
            return this._mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> Edit(CategoryAddDTO dto)
        {
            var category = this._mapper.Map<Category>(dto);
            category.UserId = Session.UserId;
            var result = await this._categoryRepository.Edit(category, Session);
            return this._mapper.Map<CategoryDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            await this._categoryRepository.Delete(id, Session);
            return true;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await this._categoryRepository.Exists(new Category { Id = id }, Session);
        }
    }
}