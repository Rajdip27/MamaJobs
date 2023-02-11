using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobLevelController : Controller
    {
        private readonly IJobLevelService _jobLevelService;
        public JobLevelController(IJobLevelService jobLevelService)
        {
            _jobLevelService = jobLevelService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Result = await _jobLevelService.GetAllAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobLevel jobLevel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobLevelService.InsertAsync(jobLevel);
                    TempData["successAlert"] = "Service Type Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(jobLevel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var Result = await _jobLevelService.FindAsync(id);
                return View(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(JobLevel jobLevel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _jobLevelService.FindAsync(jobLevel.Id);
                    if (Result != null)
                    {
                        Result.JobLevelName = jobLevel.JobLevelName;
                        await _jobLevelService.UpdateAsync(Result);
                        TempData["successAlert"] = "Job Level Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return View(jobLevel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var Result = await _jobLevelService.FindAsync(id);
                return View(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var Result = await _jobLevelService.FindAsync(id);
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

                var Result = await _jobLevelService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _jobLevelService.DeleteAsync(Result);
                TempData["successAlert"] = "job Level Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
