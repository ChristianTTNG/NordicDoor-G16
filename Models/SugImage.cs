using System.Security.Permissions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Packaging.Signing;

namespace NordicDoorTestingrep.Models
{
    public class SugImage
    {
        [Key]
        public int ImageId { get; set; }
        public string Name { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;

        public int SugID { get; set; }

        

        //------------------ Constraints -----------------------

        [ForeignKey("SugID")]
        public virtual Suggestion Suggestion { get; set; } = null!;
    }
}
