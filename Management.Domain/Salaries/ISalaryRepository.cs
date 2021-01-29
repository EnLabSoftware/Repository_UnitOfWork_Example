using Management.Domain.Interfaces;
using Management.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Salaries
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        Salary AddUserSalary(User user, float coefficientsSalary, float workdays);
    }
}
