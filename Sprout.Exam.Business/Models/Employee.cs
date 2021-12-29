using Sprout.Exam.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Models
{
    public class Employee : DataEntity
    {
        public string FullName { get; set; }
        public string Tin { get; set; }
        public DateTime Birthdate { get; set; }
        public int TypeId { get; set; }
        public decimal BasePay { get; set; }
        public bool IsDeleted { get; set; }
    }
}
