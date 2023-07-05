using Nagarro.BookReading.Application.Interfaces;
using Nagarro.BookReading.Application.Mapper;
using Nagarro.BookReading.Application.Models;
using Nagarro.BookReading.Core.Entities;
using Nagarro.BookReading.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService (IEventRepository eventRepository )
        {
            this._eventRepository = eventRepository;
        }

        public async Task<IList<EventModel>> GetEvents()
        {
            var eventList = await _eventRepository.GetEvents();
            var mapped = ObjectMapper.Mapper.Map<IList<EventModel>>(eventList);
            return mapped;

        }
        public async Task<EventModel> ViewDetails(int eventId)
        {
            var _event = await _eventRepository.ViewDetails(eventId);
            var mapped = ObjectMapper.Mapper.Map<EventModel>(_event);
            return mapped;
        }

        public async Task<int> CreateEvent(EventModel eventModel)
        {
            // mapping from viewmodel to application model
            var mapped = ObjectMapper.Mapper.Map<Event>(eventModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            ///calling application layer using mapped
            //outputting result in the same return type
            return await _eventRepository.CreateEvent(mapped);
            
          
        }

        public int UpdateEvent(EventModel eventModel)
        {
            var mapped = ObjectMapper.Mapper.Map<Event>(eventModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

           return _eventRepository.UpdateEvent(mapped);

        }
        public async Task<IList<EventModel>> MyEvents(string organiser)
        {
            var eventList = await _eventRepository.MyEvents(organiser);
            var mapped = ObjectMapper.Mapper.Map<IList<EventModel>>(eventList);
            return mapped;

        }

        public async Task<IList<CommentModel>> GetAllCommentByEventId(int eventId)
        {
            var commentList = await _eventRepository.GetAllCommentByEventId(eventId);
            var mapped = ObjectMapper.Mapper.Map<IList<CommentModel>>(commentList);
            return mapped;
        }
    }
}

