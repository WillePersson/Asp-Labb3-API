namespace Asp_Labb3_API.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Interest
    {
        public int InterestId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }
    }

}
