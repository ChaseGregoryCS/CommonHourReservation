using System.Collections.Generic;

namespace CHR
{
    public static class Users
    {
        // The list of users with administrative priveleges.
        private static readonly List<string> adminUsers = new List<string>()
                        { "admin",
                          "root" };

        public static bool isAdmin(string user)
        {
            return adminUsers.Contains(user);
        }

    }
}