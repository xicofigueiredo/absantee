using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface IHoliday
    {
        IColaborator GetColaborator();
        List<HolidayPeriod> GetHolidayPeriods();
        List<HolidayPeriod> getHolidayPeriodsInRange(DateOnly startDate, DateOnly endDate);

        int getTotalHolidayDays(List<HolidayPeriod> _holidayPeriods);
    }
}