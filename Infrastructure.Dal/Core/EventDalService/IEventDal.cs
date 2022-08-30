using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DtoModels;

namespace Infrastructure.Dal.Core.EventDalService
{
    public interface IEventDal
    {
        Task<bool> AddNewEvent(EventDto newEvent);
        List<EventDto> GetAllEvents(int userId);
        List<EventDto> GetAllEventsByUserId(int id);
        bool JoinEvent(int userId, int eventId);
    }
}
