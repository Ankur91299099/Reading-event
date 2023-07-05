using Nagarro.BookReading.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web.Interfaces
{
    public interface IEventPageService
    {
        Task<IList<EventViewModel>> GetEvents();
        Task<EventViewModel> ViewDetails(int eventId);

        Task<int> CreateEvent(EventViewModel eventViewModel);

        int UpdateEvent(EventViewModel eventViewModel);

        Task<IList<EventViewModel>> MyEvents(string organiser);
        Task<IList<CommentViewModel>> GetAllCommentByEventId(int eventId);
    }
}
