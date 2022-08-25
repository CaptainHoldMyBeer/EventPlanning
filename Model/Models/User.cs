using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Model.Models
{
    public class User: IdentityUser
    {
        public bool IsConfirmed { get; set; }
        //public List<Event> Events { get; set; }
    }
}
