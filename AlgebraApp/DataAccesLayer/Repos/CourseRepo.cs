using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Models;

namespace DataAccesLayer.Models
{
    public class CoursesRepo
    {
        private AppDbContext db = new AppDbContext();


        public List<Course> GetCourses()
        {
            return db.Courses.ToList();
        }

        public Course GetCourse(int id)
        {
            return db.Courses.Find(id);
        }

        public void CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
        }
    }
}
