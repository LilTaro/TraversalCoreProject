using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
	public class _Contact:ViewComponent
	{
		private readonly IContactService _contactService;

		public _Contact(IContactService contactService)
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
