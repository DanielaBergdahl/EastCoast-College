using EastCoastEducation.Controllers;
using EastCoastEducation.Data;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Collections.ObjectModel;
using System.Drawing;

namespace EastCoastEducation.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) 
        {
            _context = context; 
        }

        public ICollection<Course> GetAllCourses() 
        {
            return _context.Courses.OrderBy(c => c.CourseId).ToList();
        }

        public Course GetCourse(int id)
        {
            return _context.Courses.Where(c => c.CourseId == id).FirstOrDefault();
        }

        public ICollection<Course> GetCoursesByStudentId(int id)
        {
            var query = (from StudentsCourses in _context.StudentsCourses
                        join courses in _context.Courses on StudentsCourses.CourseId equals courses.CourseId
                        where StudentsCourses.StudentId == id
                        select new Course 
                            { 
                                CourseId = courses.CourseId, 
                                CourseTitle = courses.CourseTitle 
                            }).ToList();
            return query;
        }

        public Course GetCourse(string title)
        {
            return _context.Courses.Where(c => c.CourseTitle == title).FirstOrDefault();
        }

        public Course GetCourseByCategory(string category)
        {
            return _context.Courses.Where(c => c.Category == category).FirstOrDefault();
        }

        public Course GetCourseByDetails(string details)
        {
            return _context.Courses.Where(c => c.CourseDetails == details).FirstOrDefault();
        }

        public Course GetCourseByNumber(int number)
        {
            return _context.Courses.Where(c => c.CourseNumber == number).FirstOrDefault(); 
        }

        public Course GetCourseByLength(string length)
        {
            return _context.Courses.Where(c => c.CourseLength == length).FirstOrDefault();
        }

        

        public bool CourseExists(int courseId) 
        {
            return _context.Courses.Any(c => c.CourseId == courseId);
        }

        public bool CreateCourse(Course course)
        {
            _context.Add(course);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCourse(Course course)
        {
            _context.Update(course);
            return Save();
        }


    }
}
