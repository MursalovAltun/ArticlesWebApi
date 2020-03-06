using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DTO;

namespace Common.Services.Infrastructure.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetById(Guid id);

        Task<IEnumerable<CategoryDTO>> Get();

        Task<CategoryDTO> Edit(CategoryAddDTO dto);

        Task<bool> Delete(Guid id);

        Task<bool> Exists(Guid id);
    }
}