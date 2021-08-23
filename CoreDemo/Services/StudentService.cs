using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Services
{
    public class StudentService : IStudentService
    {
        #region Property  
        private readonly sql2019testContext _appDbContext;
        #endregion

        #region Constructor  
        public StudentService(sql2019testContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion
        public IQueryable<StudentDetail> GetStudentDetails()
        {
            return _appDbContext.StudentDetails;
        }
    }
}
