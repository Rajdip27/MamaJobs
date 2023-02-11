using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryService _jobCategoryService;
        public JobCategoryController(IJobCategoryService jobCategoryService)
        {
            _jobCategoryService = jobCategoryService;
        }

        public async Task< IActionResult> Index()
        {
            var Result = await _jobCategoryService.GetAllAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobCategory jobCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobCategoryService.InsertAsync(jobCategory);
                    TempData["successAlert"] = "Job Category Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(jobCategory);

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
                var Result = await _jobCategoryService.FindAsync(id);
                return View(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(JobCategory jobCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _jobCategoryService.FindAsync(jobCategory.Id);
                    if (Result != null)
                    {
                        Result.JobCategoryName = jobCategory.JobCategoryName;
                        await _jobCategoryService.UpdateAsync(Result);
                        TempData["successAlert"] = "job Category Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return View(jobCategory);

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
                var Result = await _jobCategoryService.FindAsync(id);
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
                var Result = await _jobCategoryService.FindAsync(id);
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
                var Result = await _jobCategoryService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _jobCategoryService.DeleteAsync(Result);
                TempData["successAlert"] = "Job Category Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
