using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using Project.Services;
using System;

namespace Project.Pages.Resumes
{
    public class CreateModel : PageModel
    {
        
        public ViewModel input { get; set; }
        [BindProperty(Name ="input")]
        public BindingModel result { get; set; }
        public IActionResult OnPost()
        {
            if(!ValidSubmition.CheckInput(result.Number1,result.Number2,result.Number3))
                ModelState.AddModelError("", "Please input valid numbers");
            if (ValidAge.checkIfPastDate(result.BirthDate))
               ModelState.AddModelError("result.Birthday", "Choose a date in the past");
            if (ValidAge.checkMinimumAge(result.BirthDate))
                ModelState.AddModelError("viewModel.Birthday", "You should be at least 18 years old");
            if (result.ProfileImage == null || ValidImage.CheckExtensionValidity(result.ProfileImage) != false)
                ModelState.AddModelError("viewModel.ProfileImage", "Please choose a valid image file.");
            if (!ModelState.IsValid)
                return Page();
            result.ProfilePicUrl = result.ProfileImage != null ? ValidImage.UploadFile(result.ProfileImage) : null;
            return RedirectToPage("AddToDb", result);
        }
    }
    public class Skill
    {
        public Skill() { }
        public Skill(string name, bool v)
        {
            this.name = name;
            value = v;
        }
        public string name { get; set; }
        public bool value { get; set; }
    }
}
