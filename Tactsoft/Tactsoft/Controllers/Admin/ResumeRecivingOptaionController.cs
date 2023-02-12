using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
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
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ResumeRecivingOptaion resume)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.InsertAsync(resume);
                    TempData["successAlert"] = "Job Location Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(resume);

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
                var Result = await _service.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ResumeRecivingOptaion resume)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _service.FindAsync(resume.Id);
                    if (Result != null)
                    {
                        Result.ResumeOptaionName = resume.ResumeOptaionName;
                        await _service.UpdateAsync(Result);
                        TempData["successAlert"] = "Resume Reciving Optaion Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return View(resume);

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
                var Result = await _service.FindAsync(id);
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
                var Result = await _service.FindAsync(id);
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

                var Result = await _service.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _service.DeleteAsync(Result);
                TempData["successAlert"] = "Resume Reciving Optaion Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
