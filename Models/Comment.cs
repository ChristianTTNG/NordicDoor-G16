using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorTestingrep.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; } = null!;
        public int SugID { get; set; }
        public int EmployeeID { get; set; }

        //---------------------------------- constraints -----------------------------------

        [ForeignKey("SugID")]
        public virtual Suggestion Suggestion { get; set; } = null!;

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; } = null!;

    }
}
