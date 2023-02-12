using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ResumeRecivingOptaionController : Controller
    {
        private readonly IResumeRecivingOptaionService _service;
        public ResumeRecivingOptaionController(IResumeRecivingOptaionService service)
        {
            _service = service;
        }

        public async Task< IActionResult> Index()
        {
            var Result = await _service.GetAllAsync();
            return View();
        }
    }
}
