using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using WorkItem.Web.Models;
using WorkItem.Web.Service.IService;

namespace WorkItem.Web.Controllers
{
    public class ItemTrabajoController : Controller
    {
                private readonly IItemTrabajoService _itemTrabajoService;
        public ItemTrabajoController(IItemTrabajoService itemTrabajoService)
        {
            _itemTrabajoService = itemTrabajoService;
        }

		//public IActionResult Index()
		//{
		//	return View();
		//}
		public async Task<IActionResult> Index()
        {
            List<ItemTrabajoDto>? list = new();

            ResponseDto? response = await _itemTrabajoService.GetAllItemTrabajoAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ItemTrabajoDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> ItemTrabajoCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ItemTrabajoCreate(ItemTrabajoDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _itemTrabajoService.CreateItemTrabajoAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Item creado satisfactoriamente";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Asignar(int itemTrabajoId)
        {
            ResponseDto? responseA = await _itemTrabajoService.AsignarAsync(itemTrabajoId);

			List<ItemTrabajoDto>? list = new();

			ResponseDto? response = await _itemTrabajoService.GetAllItemTrabajoAsync();

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ItemTrabajoDto>>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(list);
		}

    }

}
