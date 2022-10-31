using System;
namespace NordicDoors.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string? CommentDate { get; set; }
        public string? CommentContent { get; set; }
        public int SugID { get; set; }
    }
}

