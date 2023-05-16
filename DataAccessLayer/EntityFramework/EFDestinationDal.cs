using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using (var C = new Context())
            {
                return C.Destinations.Where(X => X.DestinationID == id).Include(X => X.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLastFourDestinations()
        {
            using(var C = new Context()) 
            {
                var values = C.Destinations.Take(4).OrderByDescending(X => X.DestinationID).ToList();
                return values;
            }
        }
    }
}
