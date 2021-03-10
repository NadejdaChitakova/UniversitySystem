using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Model;

namespace UniversitySystem.Pages.Teachers
{
    public class TeacherInfo : PageModel
    {
        private readonly UniversitySystem.Data.UniversitySystemContext _context;

        public IList<Teacher> Teachers;
        public IList<Course> Courses;
        

        public TeacherInfo(UniversitySystem.Data.UniversitySystemContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Courses = await _context.Course.ToListAsync();
            Teachers = await _context.Teacher.ToListAsync();
            var currentCourse =  Courses.FirstOrDefault(c => c.Id == c.TeacherId);
            ViewData["CurrentCourse"] = currentCourse.Name;
        }
    }
}
