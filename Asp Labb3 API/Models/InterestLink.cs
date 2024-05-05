using System.ComponentModel.DataAnnotations;

namespace Asp_Labb3_API.Models
{
    public class InterestLink
    {
        public int InterestLinkId { get; set; }

        [Required]
        public int InterestId { get; set; }
        public Interest? Interest { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        [Required]
        [Url]
        [StringLength(500, MinimumLength = 10)]
        public string URL { get; set; }
    }
}
