using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bbs.MSSQL.DAL
{
    public class UserDal : IUserDal
    {
        public User GetUser(int Id)
        {
            using(var db = new BbsDbContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id.Equals(Id));
                return user;
            }
        }

        public bool SetUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser()
        {
            throw new NotImplementedException();
        }

        List<User> IUserDal.GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
