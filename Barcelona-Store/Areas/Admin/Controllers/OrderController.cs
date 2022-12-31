using BarcelonaStore.DataAccess.Repository.IRepository;
using BarcelonaStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barcelona_Store.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}

		#region API ALLS    
		[HttpGet]
		public IActionResult GetAll()
		{
			IEnumerable<OrderHeader> orderHeaders;

			orderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
			return Json(new { data = orderHeaders });
		}
		#endregion
	}
}
