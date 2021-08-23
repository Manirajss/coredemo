using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CoreDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
        private sql2019testContext db = new sql2019testContext();

        // GET: api/StudentDetails
        public IQueryable<StudentDetail> GetStudentDetails()
        {
            return db.StudentDetails;
        }

        // GET: api/StudentDetails/5
        [ResponseType(typeof(StudentDetail))]
        public IHttpActionResult GetStudentDetail(int id)
        {
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            if (studentDetail == null)
            {
                return (IHttpActionResult)NotFound();
            }

            return (IHttpActionResult)Ok(studentDetail);
        }

        // PUT: api/StudentDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentDetail(int id, StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return (IHttpActionResult)BadRequest(ModelState);
            }

            if (id != studentDetail.Id)
            {
                return (IHttpActionResult)BadRequest();
            }

            db.Entry(studentDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailExists(id))
                {
                    return (IHttpActionResult)NotFound();
                }
                else
                {
                    throw;
                }
            }

            return (IHttpActionResult)StatusCode((int)HttpStatusCode.NoContent);
        }

        // POST: api/StudentDetails
        [ResponseType(typeof(StudentDetail))]
        public IHttpActionResult PostStudentDetail(StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return (IHttpActionResult)BadRequest(ModelState);
            }

            db.StudentDetails.Add(studentDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentDetailExists(studentDetail.Id))
                {
                    return (IHttpActionResult)Conflict();
                }
                else
                {
                    throw;
                }
            }

            return (IHttpActionResult)CreatedAtRoute("DefaultApi", new { id = studentDetail.Id }, studentDetail);
        }

        // DELETE: api/StudentDetails/5
        [ResponseType(typeof(StudentDetail))]
        public IHttpActionResult DeleteStudentDetail(int id)
        {
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            if (studentDetail == null)
            {
                return (IHttpActionResult)NotFound();
            }

            db.StudentDetails.Remove(studentDetail);
            db.SaveChanges();

            return (IHttpActionResult)Ok(studentDetail);
        }
               

        private bool StudentDetailExists(int id)
        {
            return db.StudentDetails.Count(e => e.Id == id) > 0;
        }
    }
}
