using AutoMapper;
using EastCoastEducation.Dto;
using EastCoastEducation.Model;

namespace EastCoastEducation.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Competence, CompetenceDto>();
            CreateMap<CourseDto, Course>(); // Kan tas bort?TODO att testa//ordning för update och create
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();

        }
    }
}
