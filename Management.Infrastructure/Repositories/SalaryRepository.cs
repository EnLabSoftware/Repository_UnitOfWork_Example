using Management.Domain.Interfaces;
using Management.Domain.Salaries;
using Management.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Infrastructure.Repositories
{
    public class SalaryRepository : Repository<Salary>, ISalaryRepository
    {
        public SalaryRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public Salary AddUserSalary(User user, float coefficientsSalary, float workdays)
        {
            var salary = new Salary(user, coefficientsSalary, workdays);
            if (salary.ValidOnAdd())
            {
                this.Add(salary);
                return salary;
            }
            else
                throw new Exception("Salary invalid");
        }
    }
}
