using NordicDoorApplication.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorApplication.Models
{
    public class Suggestion
    {
        [Key]
        public int SuggestionId { get; set; }
        public string SugName { get; set; } = null!;
        public int TeamID { get; set; }
        public int SugCreatorID { get; set; }
        public int ResponsibleEmployeeID { get; set; }
        public string? SugDescription { get; set; }
        public string SugCategory { get; set; } = null!;

        public bool JDISug { get; set; }
        public float progress { get; set; }
        public string SugStatus { get; set; } = null!;

        public DateTime RegisteredDate { get; set; } = DateTime.Now;
        public DateTime CompletedOrDueDate { get; set; }



        //-----------------------------------------------Constraints---------------------------------------

        [ForeignKey("TeamID")]
        public virtual Team? Team { get; set; }

        //ForeignKey("SugCreatorID")]
        //[InverseProperty("SugCreatorCon")]
        //public virtual ApplicationUser? SugCreator { get; set; }

        //[ForeignKey("ResponsibleEmployeeID")]
        //[InverseProperty("ResponsibleEmpCon")]
        //public virtual ApplicationUser? ResponsibleEmployee { get; set; }

        //public virtual ICollection<Comment>? Comments { get; set; }

        //public virtual ICollection<SugImage>? SugImages { get; set; }
    }
}
