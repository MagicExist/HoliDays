using HoliDays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IHoliDays
    {
        Task<IEnumerable<Festivo>> GetHolyDaysAsync(int year);
        Task<bool> IsHolyDay(DateTime date);

    }
}
