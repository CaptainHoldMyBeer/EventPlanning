using Infrastructure.Dal.Core.EventDalService;
using Model.DtoModels;
using System;
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
            try
            {
                return await _eventDal.AddNewEvent(newEvent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EventDto> GetAllEvents(int userId)
        {
            try
            {
                return _eventDal.GetAllEvents(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EventDto> GetAllEventsByUserId(int userId)
        {
            try
            {
                return _eventDal.GetAllEventsByUserId(userId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool JoinEvent(int userId, int eventId)
        {
            try
            {
                return _eventDal.JoinEvent(userId, eventId);
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
