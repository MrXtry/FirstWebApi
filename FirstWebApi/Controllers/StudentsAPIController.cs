using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    public class StudentsAPIController : ApiController
    {
        private StudentsEntities1 db = new StudentsEntities1();

        // GET: api/StudentsAPI
        public IQueryable<Students> GetStudents()
        {
            return db.Students;
        }

        // GET: api/StudentsAPI/5
        [Route("api/StudentsAPI/{id:int}")]
        [HttpGet]
        [ResponseType(typeof(Students))]
        public async Task<IHttpActionResult> GetStudents(int id)
        {
            Students students = await db.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // Get: api/StudentsAPI/Name
        // Get: api/StudentsAPI/?Name=name
        [Route("api/StudentsAPI/{Name}")]
        [HttpGet]
        public IQueryable<Students> GetStudents(string Name)
        {
            return db.Students.Where(i => i.StudentName == Name).ToList().AsQueryable();
        }
        [Route("api/StudentsAPI/{Name}/{RollNo}")]
        public IQueryable<Students> GetStudents(string Name, string RollNo)
        {
            return db.Students.Where(i => i.StudentName == Name && i.StudentRollNo == RollNo).ToList().AsQueryable();
        }

        // PUT: api/StudentsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudents(int id, Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.Id)
            {
                return BadRequest();
            }

            db.Entry(students).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        

        // POST: api/StudentsAPI
        [ResponseType(typeof(Students))]
        public async Task<IHttpActionResult> PostStudents(Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(students);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = students.Id }, students);
        }

        // DELETE: api/StudentsAPI/5
        [ResponseType(typeof(Students))]
        public async Task<IHttpActionResult> DeleteStudents(int id)
        {
            Students students = await db.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            db.Students.Remove(students);
            await db.SaveChangesAsync();

            return Ok(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }
    }
}