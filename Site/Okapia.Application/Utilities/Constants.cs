using System.Collections.Generic;
using Okapia.Domain.Models;

namespace Okapia.Application.Utilities
{
    public static class Constants
    {
        public static Roles Roles = new Roles();
    }

    public class Roles
    {
        public Role User = new Role(1, "صاحب کارت");
        public Role Job = new Role(2, "صاحب شغل");
        public Role Club = new Role(3, "صاحب باشگاه");
        public Role Employee = new Role(4, "کارمند شرکت");
        public Role Administrator = new Role(5, "مدیر سیستم");
    }

    public class Statuses
    {
        public const int Requested = 1;
        public const int Tracking = 2;
        public const int Registered = 3;
        public const int Denied = 3;
    }
}