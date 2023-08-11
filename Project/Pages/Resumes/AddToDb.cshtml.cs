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
        [BindProperty(SupportsGet =true)]
        public BindingModel result{ get; set; }
        public AddToDbModel(DbRepo dbRepo)
        {
            this._DbRepo = dbRepo;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            List<Skill> skills = new List<Skill>
            {
                new Skill("Java",false),
                new Skill("Python",false),
                new Skill("PHP",false),
                new Skill(".Net",false)
            };
            string Skills = "";
            int grade = 0;
            for (int i = 0; i < result.Skills.Count; i++)
            {
                if (result.Skills[i] == true)
                {
                    Skills += skills[i].name + "&";
                    grade += 10;
                }

            }
            if (result.Gender.Equals("Female"))
            {
                grade += 10;
            }
            else
            {
                grade += 5;
            }

            Resume cv = new Resume
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                BirthDate = result.BirthDate,
                Gender = result.Gender,
                Nationality = result.Nationality,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                Skills = Skills,
                ProfilePicUrl = result.ProfilePicUrl,
                grade = grade
            };

            
            await _DbRepo.AddResume(cv);
            Console.WriteLine("Add to Db Check !");
            return RedirectToPage("Index", new { Id = cv.ID });
        }
    }
    public class recieve
    {
        public recieve() { }
        public recieve(Resume resume, int grade, string skills)
        {
            this.resume = resume;
            this.grade = grade;
            Skills = skills;
        }
        public Resume? resume { get; set; }
        public int? grade { get; set; }
        public string? Skills { get; set; }
    }
}
