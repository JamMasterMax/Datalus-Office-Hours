using Datalus.Web.Domain;
using Datalus.Web.Models.Requests;
using Datalus.Web.Models.Responses;
using Datalus.Web.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Datalus.Web.Controllers.Api
{

    [RoutePrefix("api/officehours")]
    public class OfficeHoursApiController : BaseApiController
    {

        IOfficeHoursService _officeHourService;
        public OfficeHoursApiController(IOfficeHoursService officeHoursService)
        {
            _officeHourService = officeHoursService;
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                ItemsResponse<OfficeHour> response = new ItemsResponse<OfficeHour>();
                response.Items = _officeHourService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                ItemResponse<OfficeHour> response = new ItemResponse<OfficeHour>();
                response.Item = _officeHourService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route, HttpPost]
        public HttpResponseMessage Insert(OfficeHourInsertRequest model)
        {
            try
            {
                if (!IsModelValid(model))
                {
                    return this.GetInvalidResponse(model);
                }

                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = _officeHourService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return base.GetErrorResponse(ex);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(OfficeHourUpdateRequest model, int id)
        {
            try
            {
                if (!IsModelValid(model))
                {
                    return this.GetInvalidResponse(model);
                }

                _officeHourService.Update(model);
                SuccessResponse response = new SuccessResponse();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }            
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _officeHourService.Delete(id);
                SuccessResponse response = new SuccessResponse();
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
    }
}
