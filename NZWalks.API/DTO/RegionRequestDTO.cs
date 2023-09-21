using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTO
{
    public class RegionRequestDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "Code has to be a mimimum of 2 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
