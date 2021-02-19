using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversitySystem.Model;

namespace UniversitySystem.Pages.Teachers
{
    public class CreateTeacherModel : PageModel 
    {
        private readonly UniversitySystem.Data.UniversitySystemContext _context;

        [BindProperty]
        public Teacher Teacher { get; set; }

        public CreateTeacherModel(UniversitySystem.Data.UniversitySystemContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }
            _context.Add(Teacher);
            _context.SaveChanges();
            return RedirectToPage("./TeacherInfo");
        }


    }
}
