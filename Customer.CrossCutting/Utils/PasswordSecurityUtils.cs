namespace Customer.CrossCutting.Utils
{
   public static class PasswordSecurityUtils
   {
        public static string GetPasswordHash(this string password)
        {
            return SecurityUtils.HashSHA1(password);
        }
   }
}
