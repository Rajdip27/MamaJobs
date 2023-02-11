using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EmploymentStatusController : Controller
    {
        private readonly IEmploymentStatusService _employmentStatusService;
        public EmploymentStatusController(IEmploymentStatusService employmentStatusService)
        {
                _employmentStatusService = employmentStatusService;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var Result = await _employmentStatusService.GetAllAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmploymentStatus  employmentStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employmentStatusService.InsertAsync(employmentStatus);
                    TempData["successAlert"] = "Employment Status Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(employmentStatus);

            }
            catch (Exception ex)
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
                var Result = await _employmentStatusService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmploymentStatus employmentStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _employmentStatusService.FindAsync(employmentStatus.Id);
                    if (Result != null)
                    {
                        Result.EmploymentStatusName = employmentStatus.EmploymentStatusName;
                        await _employmentStatusService.UpdateAsync(Result);
                        TempData["successAlert"] = "Industry Type Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return View(employmentStatus);

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
                var Result = await _employmentStatusService.FindAsync(id);
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
                var Result = await _employmentStatusService.FindAsync(id);
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

                var Result = await _employmentStatusService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _employmentStatusService.DeleteAsync(Result);
                TempData["successAlert"] = "Employment Status Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
