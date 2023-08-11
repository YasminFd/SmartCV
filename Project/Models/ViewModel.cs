using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public String Nationality { get; set; }
        public List<bool>? Skills { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "example@gmail.com")]
        public string Email { get; set; }
        [Required]
        [Compare("Email")]
        [Display(Name = "Email Confirmation")]
        public string EmailConfirmation { get; set; }
        [Required]
        [RegularExpression(@"^\+\d{1,3}\s?\d{8,12}$", ErrorMessage = "Please enter a correct phone number")]
        [Display(Name = "Phone Number", Prompt = "+961 12345678")]
        public string? PhoneNumber { get; set; }
        [Required]
        [Range(1, 20)]
        public int Number1 { get; set; }
        [Required]
        [Range(20, 50)]
        public int Number2 { get; set; }
         [Required]
        public int Number3 { get; set; }
        [Display(Name = "Profile Picture")]
        public IFormFile? ProfileImage { get; set; }
    }
}
