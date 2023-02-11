using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobLocationController : Controller
    {
        private readonly IJobLocationService _jobLocationService;
        public JobLocationController(IJobLocationService jobLocationService)
        {
            _jobLocationService = jobLocationService;
        }

        public async Task< IActionResult> Index()
        {
            var Result=await _jobLocationService.GetAllAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobLocation jobLocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobLocationService.InsertAsync(jobLocation);
                    TempData["successAlert"] = "Job Location Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(jobLocation);

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
                var Result = await _jobLocationService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(JobLocation jobLocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _jobLocationService.FindAsync(jobLocation.Id);
                    if (Result != null)
                    {
                        Result.JobLocationName = jobLocation.JobLocationName;
                        await _jobLocationService.UpdateAsync(Result);
                        TempData["successAlert"] = "Industry Type Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return View(jobLocation);

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
                var Result = await _jobLocationService.FindAsync(id);
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
                var Result = await _jobLocationService.FindAsync(id);
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

                var Result = await _jobLocationService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _jobLocationService.DeleteAsync(Result);
                TempData["successAlert"] = "Job Location Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}
