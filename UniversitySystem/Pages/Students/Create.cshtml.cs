using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversitySystem.Data;
using UniversitySystem.Model;

namespace UniversitySystem.Pages.Students
{
    public class Create : PageModel
    {
        private readonly UniversitySystem.Data.UniversitySystemContext _context;

        public Create(UniversitySystem.Data.UniversitySystemContext context)
        {
            _context = context;
        }
        //трябва да добавим пропърти което ще се баиндва с модела
        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
