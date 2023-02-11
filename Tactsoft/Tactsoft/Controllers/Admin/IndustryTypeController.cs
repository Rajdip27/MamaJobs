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
                    TempData["successAlert"] = "Industry Type Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(industry);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var Result = await _industryTypeService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IndustryType industry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _industryTypeService.FindAsync(industry.Id);
                    if(Result != null)
                    {
                        Result.IndustryTypeName= industry.IndustryTypeName;
                        await _industryTypeService.UpdateAsync(Result);
                        TempData["successAlert"] = "Industry Type Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return View(industry);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var Result = await _industryTypeService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var Result = await _industryTypeService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCon(int id)
        {
            try
            {
                
                    var Result = await _industryTypeService.FindAsync(id);
                    if(Result == null)
                    {
                        return NotFound();
                    }
                    await _industryTypeService.DeleteAsync(Result);
                    TempData["successAlert"] = "Industry Type Delete Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
