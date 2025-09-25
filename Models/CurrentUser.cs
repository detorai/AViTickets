using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVi.Models
{
    public static class CurrentUser
    {
        public static int? UserId { get; private set; }
        public static bool IsLoggedIn => UserId.HasValue;

        public static void Login(int userId)
        {
            UserId = userId;
        }

        public static void Logout()
        {
            UserId = null;

        }
    }
}
