using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
	public class _ContactMap:ViewComponent
	{
		private readonly IContactService _contactService;

		public _ContactMap(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _contactService.GetList();
			return View(values);
		}
	}
}
