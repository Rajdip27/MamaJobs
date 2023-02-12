using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobSubCategoryController : Controller
    {
        private readonly IJobSubCategoryService _jobSubCategoryService;
        private readonly IJobCategoryService _jobCategoryService;
        public JobSubCategoryController(IJobSubCategoryService jobSubCategoryService, IJobCategoryService jobCategoryService)
        {
            _jobSubCategoryService = jobSubCategoryService;
            _jobCategoryService = jobCategoryService;
        }

        public async Task< IActionResult> Index()
        {
            var rs = await _jobSubCategoryService.GetAllAsync(x=>x.JobCategory);
            return View(rs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["JobCategoryId"] = _jobCategoryService.Dropdown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobSubCategory jobSub)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobSubCategoryService.InsertAsync(jobSub);
                    TempData["successAlert"] = "Job Sub Category Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(jobSub);

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
                ViewData["JobCategoryId"] = _jobCategoryService.Dropdown();
                var Result = await _jobSubCategoryService.FindAsync(id);
                return View(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(JobSubCategory jobSubCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _jobSubCategoryService.FindAsync(jobSubCategory.Id);
                    if (Result != null)
                    {
                        Result.JobSubCategoryName = jobSubCategory.JobSubCategoryName;
                        Result.JobCategoryId = jobSubCategory.JobCategoryId;

                        await _jobSubCategoryService.UpdateAsync(Result);
                        TempData["successAlert"] = "Job Sub Category Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                ViewData["JobCategoryId"] = _jobCategoryService.Dropdown();
                return View(jobSubCategory);

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
                var Result = await _jobSubCategoryService.FindAsync(x => x.Id == id, x => x.JobCategory);
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
                var Result = await _jobSubCategoryService.FindAsync(x=>x.Id==id,x=>x.JobCategory);
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
                var Result = await _jobSubCategoryService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _jobSubCategoryService.DeleteAsync(Result);
                TempData["successAlert"] = "Job Sub Category Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
