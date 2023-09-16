using EastCoastEducation.Data;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace EastCoastEducation.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateTeacher(Teacher teacher)
        {
            _context.Add(teacher);
            return Save();
        }

        public async Task<Teacher?> GetTeacher(int id)
            => await _context.Teachers.FindAsync(id);

        public async Task<IEnumerable<Teacher>> GetTeachers()
            => await _context.Teachers.ToListAsync();


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //public async Task<bool> TeacherExists(int id)
        //{
        //    var result = await _context.Teachers.FindAsync(id);
        //    if (result is null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public bool TeacherExists(int teacherId)
        {
            return _context.Teachers.Any(t => t.TeacherId == teacherId);
        }


        public bool UpdateTeacher(Teacher teacher)
        {
            _context.Update(teacher);
            return Save();
        }

        //public void Delete(Teacher teacher)
        //    => _context.Teachers.Remove(teacher);

        public bool DeleteTeacher(Teacher teacher)
        {
            _context.Remove(teacher);
            return Save();
        }

        Teacher ITeacherRepository.GetTeacher(int id)
        {
            return _context.Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
        }
    }
}
