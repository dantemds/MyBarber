namespace Mybarber.Validations
{
    public static class ValidaEmail
    {

        public static bool IsEmail(string email)
        {
            if (email.Contains("@"))
                return true;
            else
                return false;
        }
    }
}
