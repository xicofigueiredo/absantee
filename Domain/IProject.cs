using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface IProject
    {
        DateOnly? GetStartDate();

        DateOnly? GetEndDate();

        // List<IAssociate> GetAssociations();

        // IColaborator GetColaborator();
        // List<HolidayPeriod> GetHolidayPeriods();
    }
}