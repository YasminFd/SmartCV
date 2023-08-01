using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using Project.Models;
using Project.Services;

namespace Project.Pages.Resumes
{
    public class AddToDbModel : PageModel
    {
        public DbRepo _DbRepo;
        List<Skill> skills = new List<Skill>
        {
            new Skill("Java",false),
            new Skill("Python",false),
            new Skill("PHP",false),
            new Skill(".Net",false)
        };
        [BindProperty(SupportsGet = true)]
        public BindingModel result { get; set; }
        [BindProperty(SupportsGet = true, Name = "result")]
        public Resume cv { get; set; }
        public AddToDbModel(DbRepo dbRepo)
        {
            this._DbRepo = dbRepo;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            cv.Skills = "";
            cv.grade = 0;
            for (int i = 0; i < result.Skills.Count; i++)
            {
                if (result.Skills[i] == true)
                {
                    cv.Skills += skills[i].name + "&";
                    cv.grade += 10;
                }
                    
            }
            if (result.Gender.Equals("Female"))
            {
                cv.grade += 10;
            }
            else
            {
                cv.grade += 5;
            }
            
            await _DbRepo.AddResume(cv);

            return RedirectToPage("Index", new { Id = cv.ID });
        }
    }
}
