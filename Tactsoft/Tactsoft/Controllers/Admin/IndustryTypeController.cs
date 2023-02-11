using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class IndustryTypeController : Controller
    {
        private readonly IIndustryTypeService _industryTypeService;
        public IndustryTypeController(IIndustryTypeService industryTypeService)
        {
            _industryTypeService = industryTypeService;
        }

        public async Task< IActionResult> Index()
        {
            var Result =await _industryTypeService.GetAllAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IndustryType industry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _industryTypeService.InsertAsync(industry);
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(industry);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
