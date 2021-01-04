using Bbs.IDAL;
using Bbs.Models;
using System;

namespace Bbs.Bll
{
    public class UserBll
    {
        private IUserDal _userDal;

        public User GetUser(int Id)
        {
            return _userDal.GetUser();
        }
    }
}
