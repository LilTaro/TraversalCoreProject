using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
	public class _Feature:ViewComponent
    {
        private readonly IFeature2Service _featureService;

        public _Feature(IFeature2Service featureService)
        {
            _featureService = featureService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _featureService.GetList();
            return View(values);
        }
    }
}
