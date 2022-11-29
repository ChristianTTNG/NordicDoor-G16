namespace NordicDoorApplication.ViewModels
{
    public class TeamViewModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<CheckBoxViewModel> TeamMedlemmer { get; set; }
    }
}
