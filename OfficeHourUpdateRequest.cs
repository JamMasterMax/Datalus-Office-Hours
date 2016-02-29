using System.ComponentModel.DataAnnotations;


namespace Datalus.Web.Models.Requests
{

    public class OfficeHourUpdateRequest : OfficeHourInsertRequest
    {
    
        [Required]
        public int Id { get; set; }
        
    }
    
}
