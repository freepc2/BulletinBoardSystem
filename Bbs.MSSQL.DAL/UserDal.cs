using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL.DataContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bbs.MSSQL.DAL
{
    public class UserDal : IUserDal
    {
        private readonly IConfiguration _configuration;
        public UserDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public User GetUser(int Id)
        {
            using(var db = new BbsDbContext(_configuration))
            {
                var user = db.Users.FirstOrDefault(x => x.Id.Equals(Id));
            }
            return null;
        }

        public bool SetUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser()
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserDal.GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
