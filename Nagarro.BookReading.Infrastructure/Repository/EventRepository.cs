using Microsoft.EntityFrameworkCore;
using Nagarro.BookReading.Core.Entities;
using Nagarro.BookReading.Core.IRepositories;
using Nagarro.BookReading.Infrastructure.Data;
using Nagarro.BookReading.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Infrastructure.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly EventContext _eventContext;

        public EventRepository(EventContext eventContext) : base(eventContext)
        {
            this._eventContext = eventContext;
        }

        public async Task<IList<Event>> GetEvents()
        {
            return await _eventContext.Events.OrderBy(x => x.date).ToListAsync();
        }

        public async Task<Event> ViewDetails(int eventId)
        {
            return await _eventContext.Events.FindAsync(eventId);

        }

        public async Task<int> CreateEvent(Event _event)
        {
            var newEvent = new Event()
            { 
                title = _event.title,
                description = _event.description,
                date = _event.date,
                startTime = _event.startTime,
                location = _event.location,
                duration = _event.duration,
                organiser = _event.organiser,
                eventType = _event.eventType,
                invitees = _event.invitees

                
            };
            await _eventContext.Events.AddAsync(newEvent);
            _eventContext.SaveChanges();

            return newEvent.Id;

        }

        public int  UpdateEvent(Event _event)
        {
            _eventContext.Events.Update(_event);
            _eventContext.SaveChanges();
            return _event.Id;
        }

        public async Task<IList<Event>> MyEvents(string organiser)
        {
            var result = from _event in _eventContext.Events
                         where _event.organiser == organiser 
                         orderby _event.date
                         select _event;
            return await result.ToListAsync();

        }

        public async Task<IList<Comment>> GetAllCommentByEventId(int eventId)
        {
            var result = await (from e in _eventContext.Events
                          join c in _eventContext.Comment on
                          e.Id equals c.EventId
                          where c.EventId == eventId
                          orderby c.timeStamp
                          select new Comment()
                          { 
                              EventId = eventId,
                              comment = c.comment,
                              timeStamp = c.timeStamp

                          }).ToListAsync();
            return result;
        }


    }
}
