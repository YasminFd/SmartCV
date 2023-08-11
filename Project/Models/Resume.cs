using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Resume
    {
        public int ID { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string? Skills { get; set; }
        public string? ProfilePicUrl { get; set; }
        public int? grade { get; set; }


    }
}
