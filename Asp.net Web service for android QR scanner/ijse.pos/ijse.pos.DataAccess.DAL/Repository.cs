using ijse.pos.DataAccess.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ijse.pos.DataAccess.DAL
{
    public class Repository : IRepository
    {
        private POSContext _db = new POSContext();
        public bool Create<T>(T obj) where T : class
        {
            try
            {
                _db.Set<T>().Add(obj);
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        public bool Delete<T>(T obj) where T : class
        {
            throw new NotImplementedException();
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _db.Set<T>().FirstOrDefault<T>(predicate);
            //throw new NotImplementedException();
        }

        public List<T> FindList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _db.Set<T>().Where<T>(predicate).ToList();
            //throw new NotImplementedException();
        }

        public List<T> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T obj) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
