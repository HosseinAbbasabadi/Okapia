using System.Collections.Generic;
using Okapia.Domain.Models;

namespace Okapia.Application.Utilities
{
    public static class Constants
    {
        public static Roles Roles = new Roles();
        public static List<Controller> Controllers = new List<Controller>
        {
            new Controller(1, "Employee", "مدیریت کارمندان", 1),
            new Controller(2, "Customer", "مدیریت مشتریان", 1),
            new Controller(3, "Category", "مدیریت گروه مشاغل", 1),
            new Controller(4, "Job", "مدیریت مشاغل", 1),
            new Controller(5, "City", "مدیریت شهرها", 1),
            new Controller(6, "District", "مدیریت مناطق", 1),
            new Controller(7, "Neighborhood", "مدیریت محله ها", 1),
            new Controller(8, "Club", "مدیریت باشگاه مشتریان", 1),
            new Controller(9, "Page", "مدیریت صفحات", 1),
            new Controller(11, "Home", "صفحه اصلی", 1)
        };
    }

    public class Roles
    {
        public Role User = new Role(1, "صاحب کارت");
        public Role Job = new Role(2, "صاحب شغل");
        public Role Club = new Role(3, "صاحب باشگاه");
        public Role Employee = new Role(4, "کارمند شرکت");
        public Role Administrator = new Role(5, "مدیر سیستم");
    }
}