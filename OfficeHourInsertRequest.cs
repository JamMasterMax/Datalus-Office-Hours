using System;
using System.ComponentModel.DataAnnotations;


namespace Datalus.Web.Models.Requests
{

    public class OfficeHourInsertRequest
    {
    
        [Required]
        public string Topic { get; set; }

        [Required]
        public int InstructorId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/2015", "12/31/2100"
            , ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime SessionDate { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int SectionId { get; set; }
        
    }
    
}
