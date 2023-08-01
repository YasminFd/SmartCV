using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using Project.Services;

namespace Project.Pages.Resumes
{
    public class IndexModel : PageModel
    {
        public DbRepo _DbRepo;
        public IndexModel(DbRepo dbRepo)
        {
            this._DbRepo = dbRepo;
        }
        [BindProperty(SupportsGet =true)] 
        public int? Id { get; set; } 
        public Resume resume { get; set; }
        public void OnGet()
        {
            resume = _DbRepo.GetResumeById(Id);
        }
    }
}
