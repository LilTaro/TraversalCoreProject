using DataAccessLayer.Concrete;
using System.Linq;
using TraversalCoreProject.CQRS.Queries.DestinationQueries;
using TraversalCoreProject.CQRS.Results.DestinationResults;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;
        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.ID);
            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.DestinationCity,
                DayNight = values.DestinationTime,
                Price = values.DestinationPrice,
                Capacity = values.Capacity
            };
        }
    }
}
