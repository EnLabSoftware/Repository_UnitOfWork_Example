using Management.Domain.Users;

namespace Management.Domain.Salaries
{
    public partial class Salary
    {
        const float DAY_PRICE = 100F; // 100$, just for example
        public Salary(User user
            , float coefficientsSalary
            , float workDays) : base()
        {
            User = user;
            CoefficientsSalary = coefficientsSalary;
            WorkDays = workDays;
            TotalSalary = (decimal)((workDays * DAY_PRICE) * coefficientsSalary);
        }

        public bool ValidOnAdd()
        {
            return (UserId != 0 || User != null);
        }
    }
}
