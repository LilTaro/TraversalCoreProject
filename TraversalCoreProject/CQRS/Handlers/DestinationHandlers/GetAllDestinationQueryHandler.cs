using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TraversalCoreProject.CQRS.Results.DestinationResults;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(X => new GetAllDestinationQueryResult
            {
                ID = X.DestinationID,
                Capacity = X.Capacity,
                City = X.DestinationCity,
                DayNight = X.DestinationTime,
                Price = X.DestinationPrice
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
