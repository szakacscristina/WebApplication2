using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class CommentForMovieDetails
    {
        public string Text { get; set; }
        public bool Important { get; set; }

        public static CommentForMovieDetails FromComment(Comment comment)
        {
            return new CommentForMovieDetails
            {
                 Text = comment.Text,
                 Important = comment.Important
            };
        }
    }
}
