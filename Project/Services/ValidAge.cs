namespace Project.Services
{
    public class ValidAge
    {
        public static bool checkIfPastDate(DateTime? date)
        {
            return date > DateTime.Today;
        }
        public static bool checkMinimumAge(DateTime? date)
        {
            DateTime minimumBirthDate = DateTime.Today.AddYears(-18);
            return date > minimumBirthDate;
        }

    }
}
