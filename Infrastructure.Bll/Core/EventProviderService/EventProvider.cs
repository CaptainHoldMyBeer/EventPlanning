using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Dal.Core.EventDalService;
using Model.DtoModels;

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

        public Task<List<EventDto>> GetAllEvents()
        {
            throw new NotImplementedException("Sdsad");
        }

    }
}
