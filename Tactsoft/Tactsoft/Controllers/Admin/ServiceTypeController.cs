using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ServiceTypeController : Controller
    {
        private readonly IServiceTypeService _serviceTypeService;
        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        public async Task< IActionResult> Index()
        {
            var Result=await _serviceTypeService.GetAllAsync();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceTypeService.InsertAsync(serviceType);
                    TempData["successAlert"] = "Service Type Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(serviceType);

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
                var Result=await _serviceTypeService.FindAsync(id);
                return View(Result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ServiceType serviceType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _serviceTypeService.FindAsync(serviceType.Id);
                    if (Result != null)
                    {
                        Result.ServiceTypeName = serviceType.ServiceTypeName;
                        await _serviceTypeService.UpdateAsync(Result);
                        TempData["successAlert"] = "Service Type Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return View(serviceType);

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
                var Result = await _serviceTypeService.FindAsync(id);
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
                var Result = await _serviceTypeService.FindAsync(id);
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

                var Result = await _serviceTypeService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _serviceTypeService.DeleteAsync(Result);
                TempData["successAlert"] = "Service Type Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
