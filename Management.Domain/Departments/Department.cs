using Management.Domain.Base;
using Management.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Management.Domain.Departments
{
    [Table("Departments")]
    public partial class Department : AuditEntity<short>
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public string DepartmentName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
