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
            var sundayEaster = HoliDaysHelper.GetPalmSunday(year).AddDays(7);
            DateTime currentDate = new DateTime();
            DateTime holidayBaseOnSundayEaster = new DateTime();

            foreach (var holiday in holidayList) 
            {
                switch (holiday.IdTipo)
                {
                    case 1:
                        break;
                    case 2:
                        currentDate = new DateTime(year, holiday.Mes, holiday.Dia);
                        currentDate = HoliDaysHelper.NextMonday(currentDate);
                        holiday.Dia = currentDate.Day;
                        holiday.Mes = currentDate.Month;
                        break;
                    case 3:
                        holidayBaseOnSundayEaster = new DateTime(year, sundayEaster.Month, sundayEaster.Day);
                        holidayBaseOnSundayEaster.AddDays(holiday.DiasPascua);
                        holiday.Dia = holidayBaseOnSundayEaster.Day;
                        holiday.Mes = holidayBaseOnSundayEaster.Month;
                        break;
                    case 4:

                        holidayBaseOnSundayEaster = new DateTime(year, sundayEaster.Month, sundayEaster.Day);
                        holidayBaseOnSundayEaster.AddDays(holiday.DiasPascua);

                        currentDate = new DateTime(year, holidayBaseOnSundayEaster.Month, holidayBaseOnSundayEaster.Day);
                        currentDate = HoliDaysHelper.NextMonday(currentDate);
                        holiday.Dia = currentDate.Day;
                        holiday.Mes = currentDate.Month;
                        break;
                    

                }
            }

            return holidayList;
        }

        public Task<bool> IsHolyDay(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
