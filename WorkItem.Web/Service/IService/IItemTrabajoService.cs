using WorkItem.Web.Models;

namespace WorkItem.Web.Service.IService
{
    public interface IItemTrabajoService
    {
        Task<ResponseDto?> GetAllItemTrabajoAsync();
        Task<ResponseDto?> GetItemTrabajoByIdAsync(int id);
        Task<ResponseDto?> CreateItemTrabajoAsync(ItemTrabajoDto itemTrabajoDto);
        Task<ResponseDto?> AsignarAsync(int id);
    }
}
