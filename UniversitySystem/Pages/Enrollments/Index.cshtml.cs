using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversitySystem.Model;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Data;

namespace UniversitySystem.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        public const string ERROR_MESSAGE = "The enrollment already exist.";


        private readonly UniversitySystem.Data.UniversitySystemContext _context;

        public IList<Enrollment> Enrollments { get; set; }

        public int EnrollmentId { get; set; }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public Course currentCourse { get; set; }



        public IndexModel(UniversitySystem.Data.UniversitySystemContext context)
        {
            _context = context;
        }




        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
             
            var enrollments = _context.Enrollment.ToList();

            if (enrollments != null)
            {
                Enrollments = enrollments;


                currentCourse = _context.Course.FirstOrDefault(d => d.Id == id);
                ViewData["CourseId"] = currentCourse.Name;
            }



            EnrollmentId = (int)id;

            
           

            ViewData["StudentId"] = new SelectList(_context.Student, "Id","Id");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           

            try
            {
                Enrollment newRecord= new Enrollment();
                newRecord.CourseId = id;
                newRecord.StudentId = Enrollment.StudentId;

                _context.Enrollment.Add(newRecord);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Courses/Index");

            }
            catch (Exception)
            {
                ViewData["error"] = ERROR_MESSAGE;
                return Page();
            }



        }
    }
}

