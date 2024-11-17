using Application.DTOs;
using Application.Service;
using HoliDays.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
        [HttpGet("festivos/obtener/{año}")]
        public async Task<IActionResult> GetHolyDaysAsync(int año)
        {
            LinkedList<FestivoDTO> holidayList = await _holidayService.GetHolyDaysAsync(año);
            if (holidayList == null || holidayList.Count <= 0)
            {
                return NotFound();
            }
            return Ok(holidayList);
        }
        //Is Holiday?
        [HttpGet("festivos/verificar/{año}/{mes}/{dia}")]
        public async Task<IActionResult> IsHolyDay(int dia, int mes, int año)
        {
            DateTime date = new DateTime(año, mes, dia);
            bool isHoliday = await _holidayService.IsHolyDay(date);
            if (isHoliday) 
            {
                return Ok(new { message = "Es festivo" });
            }
            else 
            {
                return Ok(new {message = "No es festivo"});
            }
        }
    }
}
