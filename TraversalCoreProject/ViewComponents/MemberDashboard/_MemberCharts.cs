using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
	public class _MemberCharts:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
