using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using (var C = new Context())
            {
                var values = C.ContactUses.Where(X => X.Status == false).ToList();
                return values;
            }
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (var C = new Context())
            {
                var values = C.ContactUses.Where(X => X.Status == true).ToList();
                return values;
            }
        }
    }
}
