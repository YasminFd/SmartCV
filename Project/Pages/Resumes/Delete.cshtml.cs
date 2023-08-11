using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using Project.Services;

namespace Project.Pages.Resumes
{
    public class DeleteModel : PageModel
    {
        private readonly DbRepo _repository;
        public DeleteModel(DbRepo repository)
        {
            _repository = repository;
        }
        [BindProperty]
        public Models.Resume Resume { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Resume = _repository.GetResumeById(id);
            if (Resume == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Resume.ID != null)
            {
                await _repository.DeleteResume(Resume.ID);
                return RedirectToPage("List");
            }
            return NotFound();
        }
    }
}
