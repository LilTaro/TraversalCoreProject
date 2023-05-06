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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void Add(AppUser t)
        {
            _appUserDal.Insert(t);
        }

        public void Delete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser GetByID(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<AppUser> GetList()
        {
            return _appUserDal.GetList();
        }

        public void Update(AppUser t)
        {
            _appUserDal.Update(t);
        }
    }
}
