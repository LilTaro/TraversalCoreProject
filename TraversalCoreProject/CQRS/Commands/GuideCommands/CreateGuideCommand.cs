using MediatR;

namespace TraversalCoreProject.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {
        public int GuideID { get; set; }
        public string GuideName { get; set; }
        public string GuideDesc { get; set; }
        public string GuideImageUrl { get; set; }
    }
}
