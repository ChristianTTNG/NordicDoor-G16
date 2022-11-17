using System;
namespace NordicDoors.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int SuggestionId { get; set; }
        public DateTime? CommentDate { get; set; }
        public string? CommentContent { get; set; }
    }
}

