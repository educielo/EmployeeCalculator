using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Models
{
    public class DataEntity
    {
        public DataEntity()
        {
            DateCreated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
