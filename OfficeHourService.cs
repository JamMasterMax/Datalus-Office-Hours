using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Datalus.Web.Models.Requests;
using Datalus.Data;
using Datalus.Web.Domain;
using Datalus.Web.Enums;


namespace Datalus.Web.Services
{

    public class OfficeHourService : BaseService, IOfficeHoursService
    {
    
        #region -- Public Methods --
        
        public List<OfficeHour> GetAll()
        {
            List<OfficeHour> officeHours = null;

            Dictionary<int, SectionBase> sections = new Dictionary<int, SectionBase>();

            DataProvider.ExecuteCmd(GetConnection, "dbo.OfficeHours_SelectAllV2"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short resultSetNumber)
               {
                   if (resultSetNumber == 0)
                   {
                       OfficeHour officeHour = MapOfficeHour(reader, sections);

                       if (officeHours == null)
                       {
                           officeHours = new List<OfficeHour>();
                       }

                       officeHours.Add(officeHour);
                   }
                   else if (resultSetNumber == 1)
                   {
                       SectionBase section = MapSection(reader);

                       sections[section.Id] = section;
                   }
               }
            );

            foreach (var officeHour in officeHours)
            {
                officeHour.Section = sections[officeHour.Section.Id];
            }

            return officeHours;
        }
        
        
        public OfficeHour GetById(int id)
        {
            OfficeHour officeHour = null;
            int instructorId;
            int sectionId;

            Dictionary<int, UserProfileBase> userProfileDict = new Dictionary<int, UserProfileBase>();

            DataProvider.ExecuteCmd(GetConnection, "dbo.OfficeHours_SelectByIdV2"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }
               , map: delegate (IDataReader reader, short resultSetNumber)
               {
                   if (resultSetNumber == 0)
                   {
                       officeHour = MapOfficeHourCore(reader, out instructorId, out sectionId);
                   }
                   else if (resultSetNumber == 1)
                   {
                       officeHour.Section = MapSection(reader);
                   }
               }
            );

            return officeHour;
        }
        
        
        public int Insert(OfficeHourInsertRequest model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.OfficeHours_Insert"
               , inputParamMapper: delegate (SqlParameterCollection parameters)
               {
                   MapCommonParameters(model, parameters);

                   SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   idParameter.Direction = System.Data.ParameterDirection.Output;

                   parameters.Add(idParameter);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
            );
            return id;
        }


        public void Update(OfficeHourUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.OfficeHours_Update"
               , inputParamMapper: delegate (SqlParameterCollection parameters)
               {
                   MapCommonParameters(model, parameters);
                   parameters.AddWithValue("@Id", model.Id);
               }
            );
        }


        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.OfficeHours_Delete"
               , inputParamMapper: delegate (SqlParameterCollection parameters)
               {
                   parameters.AddWithValue("@Id", id);
               }
            );
        }
        
        #endregion
        
        
        #region -- Private Methods --
        
        private void MapCommonParameters(OfficeHourInsertRequest model, SqlParameterCollection parameters)
        {
            parameters.AddWithValue("@Topic", model.Topic);
            parameters.AddWithValue("@InstructorId", model.InstructorId);
            parameters.AddWithValue("@Location", model.Location);
            parameters.AddWithValue("@SessionDate", model.SessionDate);
            parameters.AddWithValue("@StartTime", model.StartTime);
            parameters.AddWithValue("@EndTime", model.EndTime);
            parameters.AddWithValue("@SectionId", model.SectionId);
        }
        
        
        private OfficeHour MapOfficeHour(IDataReader reader, Dictionary<int, SectionBase> sections)
        {
            OfficeHour officeHour;
            int instructorId;
            int sectionId;
            officeHour = MapOfficeHourCore(reader, out instructorId, out sectionId);

            SectionBase sB = new SectionBase() { Id = sectionId };
            officeHour.Section = sB;

            return officeHour;
        }
        
        
        private OfficeHour MapOfficeHourCore(IDataReader reader, out int instructorId, out int sectionId)
        {
            OfficeHour officeHour = new OfficeHour();
            int columnOrdinalPosition = 0;

            officeHour.Id = reader.GetSafeInt32(columnOrdinalPosition++);
            officeHour.Topic = reader.GetSafeString(columnOrdinalPosition++);
            instructorId = reader.GetSafeInt32(columnOrdinalPosition++);
            officeHour.Location = reader.GetSafeString(columnOrdinalPosition++);
            officeHour.SessionDate = reader.GetSafeDateTime(columnOrdinalPosition++);
            officeHour.StartTime = reader.GetSafeDateTime(columnOrdinalPosition++);
            officeHour.EndTime = reader.GetSafeDateTime(columnOrdinalPosition++);
            sectionId = reader.GetSafeInt32(columnOrdinalPosition++);

            return officeHour;
        }
        
        
        private SectionBase MapSection(IDataReader reader)
        {
            SectionBase section = new SectionBase();
            int columnOrdinalPosition = 0;

            section.Id = reader.GetSafeInt32(columnOrdinalPosition++);
            section.SectionNumberId = reader.GetSafeString(columnOrdinalPosition++);
            section.Title = reader.GetSafeString(columnOrdinalPosition++);

            section.Instructor = MapInstructor(reader);

            return section;
        }
        
        
        private InstructorBase MapInstructor(IDataReader reader)
        {
            InstructorBase instructor = new InstructorBase();
            int columnOrdinalPosition = 3;

            instructor.Id = reader.GetSafeInt32(columnOrdinalPosition++);
            instructor.FirstName = reader.GetSafeString(columnOrdinalPosition++);
            instructor.LastName = reader.GetSafeString(columnOrdinalPosition++);
            instructor.PhotoUrl = reader.GetSafeString(columnOrdinalPosition++);

            return instructor;
        }
        
    }
}
