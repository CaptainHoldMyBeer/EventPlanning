using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Model.Models
{
    public class User: IdentityUser<int>  
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public List<Event_User> EventUsers { get; set; }

    }
}
