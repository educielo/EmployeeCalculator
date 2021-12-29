using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Sprout.Exam.Business.Converters;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models;
using Sprout.Exam.WebApp;
using Sprout.Exam.WebApp.Controllers;
using Xunit;

namespace Sprout.Exam.TestProject
{
    public class EmployeeControllerTest : IClassFixture<TestFixture<Startup>>
    {
        private readonly Employee _employee;
        private readonly TestFixture<Startup> _fixture;
        private EmployeesController _controller { get; }
        public EmployeeControllerTest(TestFixture<Startup> fixture)
        {
            _fixture = fixture;
            _employee = new Employee()
            {
                Id = 1,
                FullName = "Edu Cielo",
                TypeId = 1,
                IsDeleted = false,
                Birthdate = new DateTime(1991, 06, 04),
                Tin = "4230231696"
            };

            var employeeDto = new CreateEmployeeDto() {
        
                FullName = "Edu Cielo",
                TypeId = 1,
                Birthdate = new DateTime(1991,06,04),
                Tin ="4230231696"
            };
            var _converter = new Mock<IEmployeeConverter>();
            _converter.Setup(a => a.Update(It.IsAny<EditEmployeeDto>(), _employee)).Returns(_employee);
            _converter.Setup(a => a.ConvertFromDto(employeeDto)).Returns(_employee);

        }
    }
}
