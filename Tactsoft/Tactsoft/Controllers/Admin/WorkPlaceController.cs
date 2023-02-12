using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class WorkPlaceController : Controller
    {
        private readonly IWorkPlaceService _workPlaceService;
        public WorkPlaceController(IWorkPlaceService workPlaceService)
        {
            _workPlaceService = workPlaceService;
        }

        public async Task< IActionResult> Index()
        {
            var Result = await _workPlaceService.GetAllAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkPlace workPlace)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _workPlaceService.InsertAsync(workPlace);
                    TempData["successAlert"] = "Work Place Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(workPlace);

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
                var Result = await _workPlaceService.FindAsync(id);
                return View(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(WorkPlace workPlace)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _workPlaceService.FindAsync(workPlace.Id);
                    if (Result != null)
                    {
                        Result.WorkPlaceName = workPlace.WorkPlaceName;
                        await _workPlaceService.UpdateAsync(Result);
                        TempData["successAlert"] = "Work Place Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return View(workPlace);

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
                var Result = await _workPlaceService.FindAsync(id);
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
                var Result = await _workPlaceService.FindAsync(id);
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

                var Result = await _workPlaceService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _workPlaceService.DeleteAsync(Result);
                TempData["successAlert"] = "Work Place Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
