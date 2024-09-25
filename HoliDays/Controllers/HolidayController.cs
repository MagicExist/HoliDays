using Application.Service;
using HoliDays.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoliDays.Controllers
{
    [ApiController]
    [Route("Api/")]
    public class HolidayController : ControllerBase
    {
        private readonly HolidayService _holidayService;
        public HolidayController(HolidayService holidayService) 
        {
            _holidayService = holidayService;
        }
        //Get all Holidays
        [HttpGet("GetHolidayAsync/{year}")]
        public async Task<IActionResult> GetHolyDaysAsync(int year)
        {
            Festivo[] holidayList = await _holidayService.GetHolyDaysAsync(year);
            if (holidayList == null || holidayList.Length <= 0)
            {
                return NotFound();
            }
            return Ok(holidayList);
        }
        //Is Holiday?
        [HttpGet("IsHoliday/{date}")]
        public async Task<IActionResult> IsHolyDay(DateTime date)
        {
            bool isHoliday = await _holidayService.IsHolyDay(date);
            if (isHoliday) 
            {
                return Ok(new {response = "Yeah is Holiday"});
            }
            else 
            {
                return Ok(new {response = "No is not a Holiday"});
            }
        }
    }
}
