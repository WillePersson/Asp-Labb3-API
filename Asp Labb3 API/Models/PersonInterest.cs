using System.ComponentModel.DataAnnotations;

namespace Asp_Labb3_API.Models
{
    public class PersonInterest
    {
        [Required]
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        [Required]
        public int InterestId { get; set; }
        public Interest? Interest { get; set; }
    }
}
