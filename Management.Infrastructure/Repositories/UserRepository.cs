using Management.Domain.Departments;
using Management.Domain.Interfaces;
using Management.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public User NewUser(string userName, string email, Department department)
        {
            var user = new User(userName, email, department);
            if (user.ValidOnAdd())
            {
                this.Add(user);
                return user;
            }
            else
                throw new Exception("User invalid");
        }
    }
}
