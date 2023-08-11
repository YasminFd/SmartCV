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
        public ViewModel input { get; set; }
        public void OnGet()
        {
            input = new ViewModel();
            Console.WriteLine("In edit");
            resume = dbRepo.GetResumeById(ID);
            if (input.Skills == null)
            {
                input.Skills = new List<bool>();
            }

            for (int i = 0; i < 4; i++) 
            {
                input.Skills.Add(false);
            }
            input.FirstName = resume.FirstName;
            input.LastName = resume.LastName;
            input.Email = resume.Email;
            input.BirthDate = resume.BirthDate;
            input.Gender = resume.Gender;
            input.PhoneNumber = resume.PhoneNumber;
            input.Nationality = resume.Nationality;
            input.EmailConfirmation = resume.Email;
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
            Console.WriteLine("Hold on");
            for(int i =0;i<skills.Count;i++)
            {
                if (names.Contains(skills[i].name))
                {
                    input.Skills[i] = true;
                }
            }


        }
        [BindProperty(Name = "input")]
        public BindingModel result { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ValidSubmition.CheckInput(result.Number1, result.Number2, result.Number3))
                ModelState.AddModelError("", "Please input valid numbers");
            if (ValidAge.checkIfPastDate(result.BirthDate))
                ModelState.AddModelError("result.Birthday", "Choose a date in the past");
            if (ValidAge.checkMinimumAge(result.BirthDate))
                ModelState.AddModelError("viewModel.Birthday", "You should be at least 18 years old");
            if (result.ProfileImage != null && ValidImage.CheckExtensionValidity(result.ProfileImage) == false)
                ModelState.AddModelError("viewModel.ProfileImage", "Please choose a valid image file.");
            if (!ModelState.IsValid)
                return Page();
           
            Console.WriteLine("Serverside Check!");
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
            resume = dbRepo.GetResumeById(ID);
            resume.FirstName = result.FirstName;
                resume.LastName = result.LastName;
                resume.BirthDate = result.BirthDate;
                resume.Gender = result.Gender;
                resume.Nationality = result.Nationality;
                resume.Email = result.Email;
                resume.PhoneNumber = result.PhoneNumber;
                resume.Skills = Skills;
                resume.grade = grade;
            if (result.ProfilePicUrl != null)
                resume.ProfilePicUrl = result.ProfileImage != null ? ValidImage.UploadFile(result.ProfileImage) : null;
           await dbRepo.UpdateResume(resume);
            return RedirectToPage("Index", new { Id = resume.ID });
        }
    }
}
