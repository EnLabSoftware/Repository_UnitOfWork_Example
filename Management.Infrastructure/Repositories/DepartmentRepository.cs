using Management.Domain.Departments;
using Management.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Infrastructure.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public Department AddDepartment(string departmentName)
        {
            var department = new Department(departmentName);
            if (department.ValidOnAdd())
            {
                this.Add(department);
                return department;
            }
            else
                throw new Exception("Department invalid");
        }
    }
}
