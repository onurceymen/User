using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Data;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserDal : Repository<User>, IUserDal
    {
        public EfUserDal(UserDbContext projectDbContext) : base(projectDbContext)
        {
        }
    }
}
