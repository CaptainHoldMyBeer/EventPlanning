using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.DtoModels;
using Model.Models;

namespace Infrastructure.Dal.Core.EventDalService
{
    public class EventDal : IEventDal
    {
        private readonly ApplicationContext _context;
        public EventDal(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> AddNewEvent(EventDto newEvent)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                var t = _context.Users.ToList();
                try
                {
                    var addingEvent = new Event()
                    {
                        Date = newEvent.Date,
                        Information = GetEventInfos(newEvent.AdditionalInfo),
                        Location = newEvent.Location,
                        Title = newEvent.Title
                    };


                    var addedEventEntity = await _context.Events.AddAsync(addingEvent);
                    _context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public Task<List<EventDto>> GetAllEvents()
        {
            var eventsFromDb = _context.Events.ToList();
            var eventUsersFromDb = _context.EventUsers.ToList();

            return null;
        }

        public Task<List<EventDto>> GetAllEventsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        private List<EventInfo> GetEventInfos(List<EventInfoDto> dtoObject)
        {
            var eventInfos = new List<EventInfo>();

            foreach (var keyValue in dtoObject)
            {
                eventInfos.Add(new EventInfo()
                {
                    Key = keyValue.Key,
                    Value = keyValue.Value
                });
            }

            return eventInfos;
        }
    }
}
