using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using Project.Services;

namespace Project.Pages.Resumes
{
    public class ListModel : PageModel
    {
        private readonly DbRepo _repository;
        public ListModel(DbRepo repository)
        {
            _repository = repository;
        }

        public IList<Models.Resume> Resumes { get; set; } = default!;
        public async Task OnGet()
        {
            Resumes = _repository.GetAllResumes();
        }
    }
}
