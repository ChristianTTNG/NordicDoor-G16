namespace NordicDoorTestingrep.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public bool IsAdmin { get; set; } 
        public List<CheckBoxViewModel> Teams { get; set; }
    }
}
