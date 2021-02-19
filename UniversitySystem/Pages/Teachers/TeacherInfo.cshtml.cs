using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversitySystem.Model;

namespace UniversitySystem.Pages.Teachers
{
    public class TeacherInfo : PageModel
    {
        private readonly UniversitySystem.Data.UniversitySystemContext _context;

        public IList<Teacher> Teachers;

        public TeacherInfo(UniversitySystem.Data.UniversitySystemContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Teachers = _context.Teacher.ToList();
        }
    }
}
