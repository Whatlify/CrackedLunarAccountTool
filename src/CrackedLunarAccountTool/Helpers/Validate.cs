using System.Text.RegularExpressions;

namespace CrackedLunarAccountTool.Helpers
{
    internal class Validate
    {
        public static bool IsValidMinecraftUsername(string username)
        {
            if (username.Length < 3 || username.Length > 16)
            {
                return false;
            }

            string pattern = @"^[a-zA-Z0-9_]+$";
            return Regex.IsMatch(username, pattern);
        }

        public static bool IsValidUUID(string uuid)
        {
            string pattern = @"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
            return Regex.IsMatch(uuid, pattern);
        }
    }
}
