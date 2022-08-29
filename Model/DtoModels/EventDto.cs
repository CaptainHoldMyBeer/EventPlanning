using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DtoModels
{
    public class EventDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int MaxMembers { get; set; }
        public List<EventInfoDto> AdditionalInfo { get; set; }
        public int CurrentMembers { get; set; }
    }

    public class EventInfoDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
