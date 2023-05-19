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
    public class Feature2Manager : IFeature2Service
    {
        private readonly IFeature2Dal _feature2Dal;

        public Feature2Manager(IFeature2Dal feature2Dal)
        {
            _feature2Dal = feature2Dal;
        }

        public void Add(Feature2 t)
        {
            _feature2Dal.Insert(t);
        }

        public void Delete(Feature2 t)
        {
            _feature2Dal.Delete(t);
        }

        public Feature2 GetByID(int id)
        {
            return _feature2Dal.GetByID(id);
        }

        public List<Feature2> GetList()
        {
            return _feature2Dal.GetList();
        }

        public void Update(Feature2 t)
        {
            _feature2Dal.Update(t);
        }
    }
}
