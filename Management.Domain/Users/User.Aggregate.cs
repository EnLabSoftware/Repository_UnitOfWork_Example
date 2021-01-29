using Management.Domain.Departments;
using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Users
{
    public partial class User 
    {
        public User(string userName
            , string email
            , Department department) : base()
        {
            UserName = userName;
            Email = email;
            Department = department;
        }

        public bool ValidOnAdd()
        {
            return
                // Validate userName
                !string.IsNullOrEmpty(UserName)
                // Make sure email not null and correct email format
                && !string.IsNullOrEmpty(Email)
                && new EmailAddressAttribute().IsValid(Email)
                // Make sure department not null
                && (
                    Department != null
                    || DepartmentId != 0
                );
        }
    }
}
