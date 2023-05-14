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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void Delete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public Contact GetByID(int id)
        {
            return _contactDal.GetByID(id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetList();
        }

        public void Update(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
