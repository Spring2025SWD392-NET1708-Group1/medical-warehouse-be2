using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILotCategoryService
    {
        Task<IEnumerable<LotCategoryViewDTO>> GetAllLotCategoriesAsync();
        Task<LotCategoryViewDTO?> GetLotCategoryByIdAsync(Guid id);
        Task<LotCategoryViewDTO> CreateLotCategoryAsync(LotCategoryCreateDTO lotCategoryDTO);
        Task<bool> UpdateLotCategoryAsync(Guid id, LotCategoryUpdateDTO lotCategoryDTO);
        Task<bool> DeleteLotCategoryAsync(Guid id);
    }
}

