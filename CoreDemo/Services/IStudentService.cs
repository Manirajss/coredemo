using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Services
{
    public interface IStudentService
    {
        IQueryable<StudentDetail> GetStudentDetails();
    }
}
