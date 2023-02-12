using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class DistrictController : Controller
    {
        private readonly IDistrictService _districtService;
        private readonly ICountryService _countryService;
        public DistrictController(IDistrictService districtService, ICountryService countryService)
        {
            _districtService = districtService;
            _countryService = countryService;
        }

        public async Task< IActionResult> Index()
        {
            var Result=await _districtService.GetAllAsync(x=>x.Country);
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(District district)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _districtService.InsertAsync(district);
                    TempData["successAlert"] = "District Save Successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                ViewData["CountryId"] = _countryService.Dropdown();
                return View(district);

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
                ViewData["CountryId"] = _countryService.Dropdown();
                var Result = await _districtService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(District district)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Result = await _districtService.FindAsync(district.Id);
                    if (Result != null)
                    {
                        Result.CountryId=district.CountryId;
                        Result.DistrictName=district.DistrictName;
                        await _districtService.UpdateAsync(Result);
                        TempData["successAlert"] = "District Update Successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                ViewData["CountryId"] = _countryService.Dropdown();
                return View(district);

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
                var Result = await _districtService.FindAsync(x=>x.Id==id,x=>x.Country);
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
                var Result = await _districtService.FindAsync(x => x.Id == id, x => x.Country);
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

                var Result = await _districtService.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                await _districtService.DeleteAsync(Result);
                TempData["successAlert"] = "District Delete Successfull.";
                return RedirectToAction(actionName: nameof(Index));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
