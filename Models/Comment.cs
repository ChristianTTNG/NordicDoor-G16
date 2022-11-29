using NordicDoorApplication.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorApplication.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; } = null!;
        public int SugID { get; set; }
        public int EmployeeNumber { get; set; }

        //---------------------------------- constraints -----------------------------------

        [ForeignKey("SugID")]
        public virtual Suggestion Suggestion { get; set; } = null!;

        //[ForeignKey("EmployeeNumber")]
        //public virtual ApplicationUser Employee { get; set; } = null!;
    }
}
