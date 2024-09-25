using Domain.Repository;
using HoliDays.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Persistence.DbHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class HolyDay :IHolyDays
    {
        private readonly FestivosContext _context;

        public HolyDay(FestivosContext context) 
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
