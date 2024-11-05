using WebWorkItem.Models;

namespace WebWorkItem.Service.IService
{
    public interface IItemTrabajoService
    {
        Task<ResponseDto?> GetAllItemTrabajoAsync();
        Task<ResponseDto?> GetItemTrabajoByIdAsync(int id);
        Task<ResponseDto?> CreateItemTrabajoAsync(ItemTrabajoDto itemTrabajoDto);
    }
}
