using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Model;

namespace UniversitySystem.Pages.Logins
{
    public class LoginPageModel : PageModel
    {
        public Object user { get; set; }

        private readonly UniversitySystem.Data.UniversitySystemContext _context;
        [BindProperty]
        public Login Login { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public LoginPageModel(UniversitySystem.Data.UniversitySystemContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Students = await _context.Student.ToListAsync();
            Teachers = await _context.Teacher.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {//must viewbag with username and pass
            if (!ModelState.IsValid)
            {
                RedirectToPage();   
            }
          return RedirectToPage("/Courses/Index");
        }
    }
}
