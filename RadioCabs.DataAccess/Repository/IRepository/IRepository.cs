using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioCab.DataAccess.Repository.IRepository
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
       
    }
}
