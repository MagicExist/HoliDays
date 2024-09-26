
using Application.DTOs;
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

        public async Task<LinkedList<FestivoDTO>> GetHolyDaysAsync(int year)
        {
            var holidayList = await _holiDayRepository.GetHolyDaysAsync(year);
            LinkedList<FestivoDTO> holidayDTOList = new LinkedList<FestivoDTO>();
            foreach(var holiday in holidayList)
            {
                var holidayDTO = new FestivoDTO 
                {
                    Id = holiday.Id,
                    Nombre = holiday.Nombre,
                    Dia = holiday.Dia,
                    Mes = holiday.Mes,
                    IdTipo = holiday.IdTipo,    
                };
                holidayDTOList.AddLast(holidayDTO);
            }
            return holidayDTOList;
        }

        public async Task<bool> IsHolyDay(DateTime date)
        {
            return await _holiDayRepository.IsHolyDay(date);
        }
    }
}
