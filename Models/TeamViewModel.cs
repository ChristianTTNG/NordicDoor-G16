using System.ComponentModel.DataAnnotations;

namespace NordicDoorTestingrep.Models
{
    public class TeamViewModel
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; } = null!;

        public List<CheckBoxViewModel> Employees { get; set; }
    }
}
