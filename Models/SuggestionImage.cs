using System;
namespace NordicDoors.Models
{
    public class SuggestionImage
    {
        public int SuggestionImageId { get; set; }
        public string? ImageUrl { get; set; }
        public Boolean SugState { get; set; }
        public int SuggestionId { get; set; }
    }
}

