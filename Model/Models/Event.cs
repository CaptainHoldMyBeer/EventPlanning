using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<EventInfo> Information { get; set; }
        //public List<User> Guests { get; set; }
    }
}
