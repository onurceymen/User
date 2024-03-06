using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entity;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal, UserDbContext context)
        {
            _userDal = userDal;
            _userDal = new EfUserDal(context);


        }
        public void TAdd(User t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public User TGetById(int id)
        {
            return _userDal.GetByID(id);
             
        }

        public List<User> TGetList()
        {
            return _userDal.List();
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }
    }
}
