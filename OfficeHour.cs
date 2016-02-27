using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Datalus.Web.Domain
{

    public class OfficeHour
    {
    
        public int Id { get; set; }

        public string Topic { get; set; }

        public InstructorBase Instructor { get; set; }

        public string Location { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SessionDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm tt}")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm tt}")]
        public DateTime EndTime { get; set; }

        public SectionBase Section { get; set; }

    }
    
}
