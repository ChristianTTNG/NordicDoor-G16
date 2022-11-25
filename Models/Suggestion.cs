using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorTestingrep.Models
{
    public class Suggestion
    {
        public int SuggestionId { get; set; }
        public string SugName { get; set; } = null!;
        public int TeamID { get; set; }
        public int SugCreatorID { get; set; }
        public int ResponsibleEmployeeID { get; set; }
        public string SugDescription { get; set; } = null!;
        public string SugCategory { get; set; } = null!;

        public bool JDISug { get; set; }
        public float progress { get; set; }
        public string SugStatus { get; set; } = null!;

        //public byte[] Attachments { get; set; }

        public DateTime RegisteredDate { get; set; } //= DateTime.Today;
        public DateTime CompletedOrDueDate { get; set; }



        //-----------------------------------------------Constraints---------------------------------------

        [ForeignKey("TeamID")]
        public virtual Team? Team { get; set; }

        [ForeignKey("SugCreatorID")]
        [InverseProperty("SugCreatorCon")]
        public virtual Employee? SugCreator { get; set;}

        [ForeignKey("ResponsibleEmployeeID")]
        [InverseProperty("ResponsibleEmpCon")]
        public virtual Employee? ResponsibleEmployee { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
