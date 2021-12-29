using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sprout.Exam.Business.Models;
using Sprout.Exam.DataAccess.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.TestProject
{
 
    public class EmployeeServiceTest

    {
        [Fact]
        public async Task FindEmployeeTest()
        {
            int id = 1;
            var userService = new Mock<IEmployeeService>();

            userService.Setup(x => x.FindAsync(id))
                        .ReturnsAsync(
                                        new Employee() { Id = 1,
                                        FullName = "Edu Cielo",
                                        TypeId = 1,
                                        IsDeleted = false,
                                        }
                                     );

            var service = userService.Object;
            var result = await service.FindAsync(id);
            Xunit.Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task GetAllActiveEmployeeTest()
        {
            var userService = new Mock<IEmployeeService>();

            userService.Setup(x => x.GetAllActive())
                        .ReturnsAsync(
                                        new List<Employee>() {
                                        new Employee()
                                        {
                                            Id = 1,
                                            FullName = "Edu Cielo",
                                            TypeId = 1,
                                            IsDeleted = false,
                                        },
                                        new Employee()
                                        {
                                            Id = 2,
                                            FullName = "Jane Doe",
                                            TypeId = 2,
                                            IsDeleted = false,
                                        },
                                        new Employee()
                                        {
                                            Id = 2,
                                            FullName = "John Doe",
                                            TypeId = 1,
                                            IsDeleted = false,
                                        },
                                        }
                                     );

            var service = userService.Object;
            var result = await service.GetAllActive();
            Xunit.Assert.DoesNotContain(result, a => a.IsDeleted == true);
        }

        [Fact]
        public async Task UpdateEmployeeTest()
        {
            var employee = new Employee()
            {
                Id = 1,
                FullName = "Edu Cielo",
                TypeId = 1,
                IsDeleted = false,
            };

            var userService = new Mock<IEmployeeService>();
            userService.Setup(x => x.Update(It.IsAny<Employee>()))
                .Verifiable();
            var service = userService.Object;
           await service.Update(employee);

        }
        [Fact]
        public async Task DeleteEmployeeTest()
        {
            var employee = new Employee()
            {
                Id = 1,
                FullName = "Edu Cielo",
                TypeId = 1,
                IsDeleted = false,
            };

            var userService = new Mock<IEmployeeService>();
            userService.Setup(x => x.Delete(It.IsAny<Employee>()))
                .Verifiable();
            var service = userService.Object;
            await service.Delete(employee);

        }
    }
}
