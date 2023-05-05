using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void Add(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void Delete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation GetByID(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public List<Reservation> GetList()
        {
            return _reservationDal.GetList();
        }

        public List<Reservation> GetListWithReservationByApproved(int id)
        {
            return _reservationDal.GetListWithReservationByApproved(id);
        }

        public List<Reservation> GetListWithReservationByPreviousApproval(int id)
        {
            return _reservationDal.GetListWithReservationByPreviousApproval(id);
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            return _reservationDal.GetListWithReservationByWaitApproval(id);
        }

        public void Update(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
