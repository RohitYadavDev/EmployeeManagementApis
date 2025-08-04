namespace DemoApis.Helpers
{
    public class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        //public static bool VerifyPassword(string password, string hashedPassword)
        //{
        //    if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
        //    {
        //        throw new ArgumentException("Password and hashed password cannot be null or empty.");
        //    }
        //    var hashedInputPassword = HashPassword(password);
        //    return hashedInputPassword == hashedPassword;
        //}
    }
}
