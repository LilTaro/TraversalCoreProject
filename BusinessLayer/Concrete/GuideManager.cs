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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void Add(Guide t)
        {
            _guideDal.Insert(t);
        }

        public void ChangeToFalseByGuide(int id)
        {
            _guideDal.ChangeToFalseByGuide(id);
        }

        public void ChangeToTrueByGuide(int id)
        {
            _guideDal.ChangeToTrueByGuide(id);
        }

        public void Delete(Guide t)
        {
            _guideDal.Delete(t);
        }

        public Guide GetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public List<Guide> GetList()
        {
            return _guideDal.GetList();
        }

        public void Update(Guide t)
        {
            _guideDal.Update(t);
        }
    }
}
