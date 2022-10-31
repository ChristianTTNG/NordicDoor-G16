using System;
namespace NordicDoors.Models
{
    public class Suggestion
    {
        public int SuggestionID { get; set; }
        public string? SugName { get; set; }
        public string? Description { get; set; }
        public string? RegisteredDate { get; set; }
        public string? CompletedDate { get; set; }
        public string? SugCategory { get; set; }
        public int EmployeeID { get; set; }
        public int ResponsibleEmp { get; set; }
        public int TeamID { get; set; }
        public string? DueDate { get; set; }
        public string? SugStatus { get; set; }
        public Boolean IsJDI { get; set; }
    }
}

