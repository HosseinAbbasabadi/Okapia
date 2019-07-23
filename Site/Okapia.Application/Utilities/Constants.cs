using System.Collections.Generic;
using Okapia.Domain.Models;

namespace Okapia.Application.Utilities
{
    public static class Constants
    {
        public static Roles Roles = new Roles();
        public static Statuses Statuses = new Statuses();
    }

    public class Roles
    {
        public Role User = new Role(1, "صاحب کارت");
        public Role Job = new Role(2, "صاحب شغل");
        public Role Club = new Role(3, "صاحب باشگاه");
        public Role Employee = new Role(4, "کارمند شرکت");
        public Role Administrator = new Role(5, "مدیر سیستم");

        public IEnumerable<Role> ToList()
        {
            return new List<Role>
            {
                User,
                Job,
                Club,
                Employee,
                Administrator
            };
        }
    }

    public class Statuses
    {
        public Status Requested = new Status(1, "درخواست جدید");
        public Status Tracking = new Status(2, "درحال پیگیری");
        public Status Registered = new Status(3, "ثبت مشاغل شده");
        public Status Denied = new Status(4, "رد شده");

        public IEnumerable<Status> ToList()
        {
            return new List<Status>
            {
                Requested,
                Tracking,
                Registered,
                Denied
            };
        }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Status(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}