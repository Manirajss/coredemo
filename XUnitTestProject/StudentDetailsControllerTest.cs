using CoreDemo.Controllers;
using CoreDemo.Models;
using CoreDemo.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    public class StudentDetailsControllerTest
    {
        #region Property  
        public Mock<IStudentService> mock = new Mock<IStudentService>();
        #endregion
        [Fact]
        public void GetStudentDetails()
        {
            var studentList = new List<StudentDetail>();
            var studentDetail = new StudentDetail() { FirstName = "Test", LastName = "user", Id = 1, Age = 12 };
            studentList.Add(studentDetail);
            mock.Setup(p => p.GetStudentDetails()).Returns(studentList.AsQueryable());
            var studentDetailsCon = new StudentDetailsController(mock.Object);
            var result = studentDetailsCon.GetStudentDetails().ToList();
            var isTrue = studentList.All(result.Contains) && (studentList.Count == result.Count);
            Assert.True(isTrue);
        }
    }
}

