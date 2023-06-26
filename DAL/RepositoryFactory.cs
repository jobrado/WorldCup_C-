using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryFactory<T>
    {
        public static IRepository<T> GetRepository() => new JSONRepository<T>();
    }
}
