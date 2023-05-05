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
    public class EFReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListWithReservationByApproved(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(X => X.Destination).Where(X => X.Status == "Onaylandı" && X.AppUserID == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByPreviousApproval(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(X => X.Destination).Where(X => X.Status == "Geçmiş Rezervasyon" && X.AppUserID == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context=new Context()) 
            {
                return context.Reservations.Include(X => X.Destination).Where(X => X.Status == "Onay Bekliyor" && X.AppUserID == id).ToList();
            }
        }
    }
}
