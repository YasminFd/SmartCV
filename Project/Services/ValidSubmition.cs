namespace Project.Services
{
    public class ValidSubmition
    {
        public static bool CheckInput(int a, int b , int c)
        {
            if (a + b == c)
                return true;
            return false;

        }
    }
}
