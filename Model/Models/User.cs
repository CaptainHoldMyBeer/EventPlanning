﻿using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Model.Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}