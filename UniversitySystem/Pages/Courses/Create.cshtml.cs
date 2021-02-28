using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Data;
using UniversitySystem.Model;

namespace UniversitySystem.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly UniversitySystem.Data.UniversitySystemContext _context;

        [BindProperty]
        public Course Course { get; set; }
        public CreateModel(UniversitySystem.Data.UniversitySystemContext context)
        {
            _context = context;
        }

         
        public IActionResult OnGet()
        {
            ViewData["Teacher"] = new SelectList(_context.Teacher,"Id", "Id","FirstName" ,"LastName");
            ViewData["Topic"] = new SelectList(_context.CourseTopic,"Id", "Topic");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()  
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Course.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
