using Nagarro.BookReading.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web.Interfaces
{
    public interface ICommentPageService
    {

        Task<int> PostComment(CommentViewModel response);

        Task<IList<CommentViewModel>> GetComments();

        Task<CommentViewModel> ViewComment(int commentId);

        int EditComment(CommentViewModel response);
    }
}
