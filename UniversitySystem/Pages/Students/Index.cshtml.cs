using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Data;
using UniversitySystem.Model;

namespace UniversitySystem.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly UniversitySystem.Data.UniversitySystemContext _context;

        public IndexModel(UniversitySystemContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; }
        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
