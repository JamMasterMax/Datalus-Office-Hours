using Datalus.Web.Models.ViewModels;
using System.Web.Mvc;


namespace Datalus.Web.Controllers
{

    [RoutePrefix("OfficeHours")]
    public class OfficeHoursController : BaseController
    {
    
        [Route, HttpGet]
        public ActionResult Index()
        {
            BaseViewModel model = new BaseViewModel();
            model = DecorateViewModel(model);
            return View(model);
        }
    
        [Route("Create")] 
        [Route("Create/{instructorId:int}/{sectionId:int}")]
        [Route("{instructorId:int}/{sectionId:int}/{id:int}/Edit"), HttpGet]
        public ActionResult Create(int id = 0, int instructorId = 0, int sectionId = 0)
        {
            OfficeHourViewModel model = new OfficeHourViewModel();
            model = DecorateViewModel(model);
            model.Id = id;
            model.InstructorId = instructorId;
            model.SectionId = sectionId;
            return View(model);
        }
        
    }
    
}
