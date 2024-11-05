using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WorkItem.Web.Models;
using WorkItem.Web.Service.IService;

namespace WorkItem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IItemTrabajoService _itemTrabajoService;
	
		public HomeController(ILogger<HomeController> logger, IItemTrabajoService itemTrabajoService)
        {
            _logger = logger;
			_itemTrabajoService = itemTrabajoService;
		}

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

		//public Task<IActionResult> ItemTrabajoIndex()
		//{
		//	return View();
		//}

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
					TempData["success"] = "Coupon created successfully";
					return RedirectToAction(nameof(Index));
				}
				else
				{
					TempData["error"] = response?.Message;
				}
			}
			return View(model);
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
