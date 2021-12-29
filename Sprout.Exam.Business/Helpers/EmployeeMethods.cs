using Sprout.Exam.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Helpers
{

    /// <summary>
    /// Computations for a Regular Employee
    /// </summary>
    public class RegularEmployee : Employee
    {
        public RegularEmployee(Employee employee)
        {
            BasePay = employee.BasePay;
            Birthdate = employee.Birthdate;
            FullName = employee.FullName;
            Tin = employee.Tin;
            TypeId = employee.TypeId;
        }
        /// <summary>
        /// Compute Total amount give the absencies of the employee
        /// </summary>
        /// <param name="absencies"></param>
        /// <returns></returns>
        public decimal ComputeTotalSalary(decimal absencies)
        {
            var absenciesTotal = GetDeductionsFromAbsencies(absencies);
            var taxAmount = ComputeTaxAmount();
            return Decimal.Round(BasePay - (taxAmount + absenciesTotal), 2);
        }

        /// <summary>
        /// Compute the total deductions from absencies
        /// </summary>
        /// <param name="absencies"></param>
        /// <param name="basePay"></param>
        /// <returns></returns>
        public decimal GetDeductionsFromAbsencies(decimal absencies)
        {
            var rate = BasePay / 22;
            var totalAbsencies = rate * absencies;
            return totalAbsencies;
        }

        /// <summary>
        /// Compute the tax amout of a regular employee
        /// </summary>
        /// <returns></returns>
        public decimal ComputeTaxAmount()
        {
            return BasePay * 0.12M;
        }
    }

    /// <summary>
    /// Computations for a Contractual Employee
    /// </summary>
    public class ContractualEmployee : Employee
    {
        public ContractualEmployee(Employee employee)
        {
            BasePay = employee.BasePay;
            Birthdate = employee.Birthdate;
            FullName = employee.FullName;
            Tin = employee.Tin;
            TypeId = employee.TypeId;
        }

        public decimal ComputeTotalSalary(decimal workedDays)
        {
            return Decimal.Round(workedDays * BasePay, 2);
        }

    }

}
