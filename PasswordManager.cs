using System.Security.Cryptography;
using System.Text;
namespace osu_launcher
{
    public class PasswordProtector
    {
        public static byte[] EncryptPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] encryptedPassword = ProtectedData.Protect(passwordBytes, null, DataProtectionScope.CurrentUser);
            return encryptedPassword;
        }

        public static string DecryptPassword(byte[] encryptedPassword)
        {
            byte[] decryptedPassword = ProtectedData.Unprotect(encryptedPassword, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedPassword);
        }
    }
}
