using Domain.Repository;
using HoliDays.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DbHelpers;

namespace Persistence.Repositories
{
    public class HoliDay :IHoliDays
    {
        private readonly FestivosContext _context;

        public HoliDay(FestivosContext context) 
        {
            _context = context;
        }


        public async Task<IEnumerable<Festivo>> GetHolyDaysAsync(int year)
        {
            var holidayList = await _context.Festivos.ToArrayAsync();
            return HoliDaysHelper.GetHolyDayList(year, holidayList);
        }

        public async Task<bool> IsHolyDay(DateTime date)
        {
            var holidayList = await _context.Festivos.ToArrayAsync();
            holidayList = HoliDaysHelper.GetHolyDayList(date.Year, holidayList);
            var isHoliday = holidayList.Any(holiday => holiday.Dia == date.Day && holiday.Mes == date.Month);
            return isHoliday;
        }
    }
}
