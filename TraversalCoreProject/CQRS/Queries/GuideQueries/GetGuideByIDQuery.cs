using MediatR;
using TraversalCoreProject.CQRS.Results.GuideResults;

namespace TraversalCoreProject.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery:IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int guideID)
        {
            GuideID = guideID;
        }

        public int GuideID { get; set; }
    }
}
