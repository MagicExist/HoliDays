
using Domain.Repository;
using HoliDays.Models;

namespace Application.Service
{
    public class HolidayService
    {
        private readonly IHoliDays _holiDayRepository;
        public HolidayService(IHoliDays holiDayRepository)
        {
            _holiDayRepository = holiDayRepository;
        }

        public async Task<Festivo[]> GetHolyDaysAsync(int year)
        {
            return await _holiDayRepository.GetHolyDaysAsync(year);
        }

        public async Task<bool> IsHolyDay(DateTime date)
        {
            return await _holiDayRepository.IsHolyDay(date);
        }
    }
}
