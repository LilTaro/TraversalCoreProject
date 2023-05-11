using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using TraversalCoreProject.CQRS.Commands.GuideCommands;
using TraversalCoreProject.CQRS.Queries.GuideQueries;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/GuideMediatR")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }
        [Route("GetGuide/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetGuide(int id)
        {
            var values = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }
        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [Route("AddGuide/{id}")]
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command) 
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
