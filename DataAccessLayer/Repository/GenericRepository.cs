﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		public void Delete(T t)
		{
			using var C = new Context();
			C.Remove(t);
			C.SaveChanges();
		}

        public T GetByID(int id)
        {
			using var C = new Context();
			return C.Set<T>().Find(id);
        }

        public List<T> GetList()
		{
			using var C = new Context();
			return C.Set<T>().ToList();
		}

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
			using var C = new Context();
			return C.Set<T>().Where(filter).ToList();
        }

        public void Insert(T t)
		{
			using var C = new Context();
			C.Add(t);
			C.SaveChanges();
		}

		public void Update(T t)
		{
			using var C = new Context();
			C.Update(t);
			C.SaveChanges();
		}
	}
}
