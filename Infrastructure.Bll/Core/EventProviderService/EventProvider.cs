using Infrastructure.Dal.Core.EventDalService;
using Model.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Bll.Core.EventProviderService
{
    public class EventProvider: IEventProvider
    {
        private readonly IEventDal _eventDal;
        public EventProvider(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }
        public async Task<bool> CreateEvent(EventDto newEvent)
        {
           return await _eventDal.AddNewEvent(newEvent);
        }

        public List<EventDto> GetAllEvents()
        {
            return _eventDal.GetAllEvents();
        }

        public List<EventDto> GetAllEventsByUserId(int userId)
        {
            return _eventDal.GetAllEventsByUserId(userId);
        }

        public bool JoinEvent(int userId, int eventId)
        {
            return _eventDal.JoinEvent(userId, eventId);
        }

    }
}
