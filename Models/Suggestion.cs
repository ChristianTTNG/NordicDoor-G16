using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoors.Models

{
    public class Suggestion
    {
        [Key]
        public int SuggestionId { get; set; }
        public string? SugName { get; set; }
        public string? Description { get; set; }
        public string? RegisteredDate { get; set; }
        public string? CompletedDate { get; set; }
        public string? SugCategory { get; set; }
        public int EmployeeId { get; set; }
        public int ResponsibleEmp { get; set; }
        public int TeamId { get; set; }
        public string? DueDate { get; set; }
        public string? SugStatus { get; set; }
        public Boolean IsJdi { get; set; }
    }
}

