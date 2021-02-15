using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Data;
using UniversitySystem.Model;

namespace UniversitySystem.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly UniversitySystem.Data.UniversitySystemContext _context;

        public IndexModel(UniversitySystem.Data.UniversitySystemContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Course.ToListAsync();
        }
    }
}
