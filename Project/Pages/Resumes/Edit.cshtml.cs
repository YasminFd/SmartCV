using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Services;

namespace Project.Pages.Resumes
{
    public class EditModel : PageModel
    {
        public DbRepo dbRepo;
        public EditModel(DbRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        public Resume resume { get; set; }
        [BindProperty]
        public ViewModel input { get; set; }
        public void OnGet()
        {
            resume = dbRepo.GetResumeById(ID);
            input.FirstName = resume.FirstName;
            input.LastName = resume.LastName;
            input.Email = resume.Email;
            input.BirthDate = resume.BirthDate;
            input.Gender = resume.Gender;
            input.PhoneNumber = resume.PhoneNumber;
            string[] parts = resume.Skills.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            // Remove any trailing empty strings (if any) from the last ampersand(s)
            List<string> names = new List<string>();
            foreach (string part in parts)
            {
                if (!string.IsNullOrWhiteSpace(part))
                {
                    names.Add(part);
                }
            }
            List<Skill> skills = new List<Skill>
            {
                new Skill("Java",false),
                new Skill("Python",false),
                new Skill("PHP",false),
                new Skill(".Net",false)
            };
            for(int i =0;i<skills.Count;i++)
            {
                if (names.Contains(skills[i].name))
                {
                    input.Skills[i] = true;
                }
            }


        }
    }
}
