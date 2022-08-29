using Model.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Bll.Core.EventProviderService
{
    public interface IEventProvider
    {
        Task<bool> CreateEvent(EventDto newEvent);

        List<EventDto> GetAllEvents();

        List<EventDto> GetAllEventsByUserId(int userId);

        bool JoinEvent(int userId, int eventId);
    }
}
