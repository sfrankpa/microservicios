using WebWorkItem.Models;
using WebWorkItem.Service.IService;
using WebWorkItem.Utility;

namespace WebWorkItem.Service
{
    public class ItemTrabajoService: IItemTrabajoService
    {
        private readonly IBaseService _baseService;
        public ItemTrabajoService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateItemTrabajoAsync(ItemTrabajoDto itemTrabajoDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = itemTrabajoDto,
                Url = SD.ItemTrabajoAPIBase + "https://localhost:7248/api/ItemTrabajo"
			});
        }

        
        public async Task<ResponseDto?> GetAllItemTrabajoAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = //SD.ItemTrabajoAPIBase +
                      "https://localhost:7248/api/ItemTrabajo/GetItemTrabajoAll"
            });
        }

       
        public async Task<ResponseDto?> GetItemTrabajoByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ItemTrabajoAPIBase + "https://localhost:7248/api/ItemTrabajo/GetItemTrabajoById/" + id
            });
        }       
    }
}
