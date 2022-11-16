using System;
namespace NordicDoors.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? CommentDate { get; set; }
        public string? CommentContent { get; set; }
        public int SugId { get; set; }
    }
}

