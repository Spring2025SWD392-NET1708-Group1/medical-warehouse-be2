using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IItemService
    {
        Task<ItemViewDTO> CreateItemAsync(ItemCreateDTO itemDTO);
        Task<bool> DeleteItemAsync(Guid id);
        Task<IEnumerable<ItemViewDTO>> GetAllItemsAsync();
        Task<ItemViewDTO?> GetItemByIdAsync(Guid id);
        Task<bool> UpdateItemAsync(Guid id, ItemUpdateDTO itemDTO);
    }
}
