using System.Collections.Generic;
using System.Data.SqlClient;
using Sabio.Web.Domain;
using Sabio.Web.Models.Requests;
using System.Data;


namespace Datalus.Web.Services
{

    public interface IOfficeHoursService
    {
    
        int Insert(OfficeHourInsertRequest model);
        
        void Update(OfficeHourUpdateRequest model);
        
        void Delete(int id);
        
        OfficeHour GetById(int id);
        
        List<OfficeHour> GetByInstructorId(int InstructorId);
        
        List<OfficeHourBase> GetByUserProfileId(int id);
        
        List<OfficeHour> GetAll();
        
        void MapCommonParameters(OfficeHourInsertRequest model, SqlParameterCollection parameters);
        
        OfficeHour MapOfficeHour(IDataReader reader, Dictionary<int, SectionBase> sectionDict);
        
        OfficeHour MapOfficeHourCore(IDataReader reader, out int instructorId, out int sectionId);
        
        OfficeHourBase MapOfficeHourBase(IDataReader reader);
        
        SectionBase MapSection(IDataReader reader);
        
    }
    
}
