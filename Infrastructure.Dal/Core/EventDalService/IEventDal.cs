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
        Task<List<EventDto>> GetAllEvents();
        Task<List<EventDto>> GetAllEventsByUserId(int id);
    }
}
