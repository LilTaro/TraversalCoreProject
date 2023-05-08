using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void Add(Announcement t)
        {
            _announcementDal.Insert(t);
        }

        public void Delete(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement GetByID(int id)
        {
            return _announcementDal.GetByID(id);
        }

        public List<Announcement> GetList()
        {
            return _announcementDal.GetList();
        }

        public void Update(Announcement t)
        {
            _announcementDal.Update(t);
        }
    }
}
