using Model;
using Model.DtoModels;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        Title = newEvent.Title,
                        MaxMembers = newEvent.MaxMembers
                    };


                    var addedEventEntity = await _context.Events.AddAsync(addingEvent);
                    _context.SaveChanges();


                    var newEventUser = new Event_User
                    {
                        UserId = newEvent.UserId,
                        EventId = addedEventEntity.Entity.Id
                    };

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

        public List<EventDto> GetAllEvents()
        {
            var eventUsersFromDb = _context.EventUsers.Where(p => p.Event.Date >= DateTime.Today);

            var userEvents = new List<EventDto>();

            foreach (var foundEvent in eventUsersFromDb)
            {
                userEvents.Add(new EventDto
                {
                    Date = foundEvent.Event.Date,
                    Location = foundEvent.Event.Location,
                    Title = foundEvent.Event.Title,
                    AdditionalInfo = GetEventInfoDtos(foundEvent.Event.Information),
                    MaxMembers = foundEvent.Event.MaxMembers,
                    CurrentMembers = foundEvent.Event.EventUsers.Count
                });
            }

            return userEvents;
        }

        public List<EventDto> GetAllEventsByUserId(int id)
        {
            var eventUsersFromDb = _context.EventUsers.Where(p => p.UserId == id && p.Event.Date >= DateTime.Today);

            var userEvents = new List<EventDto>();

            foreach (var foundEvent in eventUsersFromDb)
            {
                userEvents.Add(new EventDto
                { 
                    Date = foundEvent.Event.Date,
                    Location = foundEvent.Event.Location,
                    Title = foundEvent.Event.Title,
                    AdditionalInfo = GetEventInfoDtos(foundEvent.Event.Information),
                    MaxMembers = foundEvent.Event.MaxMembers,
                    CurrentMembers = foundEvent.Event.EventUsers.Count
                });
            }

            return userEvents;
        }

        public bool JoinEvent(int userId, int eventId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newEventUser = new Event_User
                    {
                        UserId = userId,
                        EventId = eventId
                    };

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

        private List<EventInfoDto> GetEventInfoDtos(List<EventInfo> infoObject)
        {
            var eventInfos = new List<EventInfoDto>();

            foreach (var keyValue in infoObject)
            {
                eventInfos.Add(new EventInfoDto
                {
                    Key = keyValue.Key,
                    Value = keyValue.Value
                });
            }

            return eventInfos;
        }
    }
}
