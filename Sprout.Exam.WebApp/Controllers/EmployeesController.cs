using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Services;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Business.Converters;
using Sprout.Exam.Business.Helpers;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IEmployeeConverter _converter;
        public EmployeesController(IEmployeeService service,
            IEmployeeConverter converter)
        {
            _service = service;
            _converter = converter;
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllActive();
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.FindAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            var employee = await _service.FindAsync(input.Id);
            if (employee == null) return NotFound();
            employee = _converter.Update(input, employee);
            await _service.Update(employee);
            return Ok(employee);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            var employee = _converter.ConvertFromDto(input);
           var newEmployee =  await _service.CreateAsync(employee);
            return Created($"/api/employees/{newEmployee.Id}", newEmployee.Id);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.FindAsync(id);
            if (result == null) return NotFound();
            result.IsDeleted = true;
            await _service.Update(result);
            return Ok(id);
        }



        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        /// 
        [HttpPost("{id}/calculate/")]
        public async Task<IActionResult> Calculate(int id, [FromBody] CalculationDto dto)
        {
            var employee = await _service.FindAsync(id);
            if (employee == null) return NotFound("Employee not found");
            var salaryTuple = SalaryCalculationFactory.ComputeSalary(employee, dto);
            if (salaryTuple.Item2 == false)
                return NotFound("Employee Type Not Found!");
            else
                return Ok(salaryTuple.Item1);
        }

    }
}
