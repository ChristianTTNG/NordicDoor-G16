using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoorTestingrep.Models
{
    public class SuggestionViewModel
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
        //List<Comment>? Comments { get; set; }

        public DateTime RegisteredDate { get; set; } //= DateTime.Today;
        public DateTime CompletedOrDueDate { get; set; }
    }
}
