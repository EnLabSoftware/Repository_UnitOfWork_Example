using Management.Domain.Departments;
using Management.Domain.Interfaces;
using Management.Domain.Salaries;
using Management.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.API.Services
{
    public class DepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISalaryRepository _salaryRepository;

        public DepartmentService(IUnitOfWork unitOfWork
            , IDepartmentRepository departmentRepository
            , IUserRepository userRepository
            , ISalaryRepository salaryRepository)
        {
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
            _salaryRepository = salaryRepository;
        }

        public async Task<bool> AddAllEntitiesAsync()
        {
            // create new Department
            var departMentName = $"department_{Guid.NewGuid():N}";
            var department = _departmentRepository.AddDepartment(departMentName);

            // create new User with above Department
            var userName = $"user_{Guid.NewGuid():N}";
            var userEmail = $"{Guid.NewGuid():N}@gmail.com";
            var user = _userRepository.NewUser(userName, userEmail, department);

            // create new Salary with above User
            float coefficientsSalary = new Random().Next(1, 15);
            float workdays = 22;
            var salary = _salaryRepository.AddUserSalary(user, coefficientsSalary, workdays);

            // Commit all changes with one single commit
            var saved = await _unitOfWork.CommitAsync();

            return saved > 0;
        }
    }
}
