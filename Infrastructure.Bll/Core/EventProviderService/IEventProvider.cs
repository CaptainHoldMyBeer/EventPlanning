using Model.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Bll.Core.EventProviderService
{
    public interface IEventProvider
    {
        Task<bool> CreateEvent(EventDto newEvent);

        Task<List<EventDto>> GetAllEvents();
    }
}
