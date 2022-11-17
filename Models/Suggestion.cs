using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordicDoors.Models

{
    public class Suggestion
    {
        [Key]
        public int SuggestionId { get; set; }

        [Required]
        public string SugName { get; set; }

        public string? SugDescription { get; set; }

        [Required]
        public DateOnly RegisteredDate { get; set; }

        public DateOnly? CompletedDate { get; set; }

        public string? SugCategory { get; set; }

        [Required]
        public string SugCreator { get; set; }

        [Required]
        public string SugResponsible { get; set; }

        [Required]
        public int TeamId { get; set; }

        public string? EstTime { get; set; }

        public string? SugStatus { get; set; }

        public bool IsJdi { get; set; } = false;
    }
}

