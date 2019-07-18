﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Okapia.Domain.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}