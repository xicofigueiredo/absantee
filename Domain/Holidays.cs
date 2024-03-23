using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Holidays
    {
        private List<IHoliday> _holidays;


        public Holidays(List<IHoliday> Holidays)
        {
            _holidays = new List<IHoliday>(Holidays);
        }



        public void addHoliday(IHoliday holiday)
        {
            _holidays.Add(holiday);
        }

        public List<IHoliday> GetHolidays()
        {
            return _holidays;
        }

        public int GetTotalDiasFeriasOfColaboratorinRange(DateOnly startDate, DateOnly endDate, IColaborator colaborator) {
            List<HolidayPeriod> holidayPeriodsinRange;
            int totalDiasFeriasDoColaborador=0;
    
            foreach (var holiday in _holidays) {
                if (holiday.GetColaborator().Equals(colaborator)) {
                    holidayPeriodsinRange = holiday.getHolidayPeriodsInRange(startDate,endDate);
                    totalDiasFeriasDoColaborador = holiday.getTotalHolidayDays(holidayPeriodsinRange);
                }
            }
 
            return totalDiasFeriasDoColaborador;
        }
        
        // public List<IHoliday> GetHolidaysOfColaborator(IColaborator colaborator)
        // {
        //     List<IHoliday> holidaysOfColaborator = new List<IHoliday>();

        //     foreach (var holiday in _holidays)
        //     {
        //         if (holiday.GetColaborator() == colaborator)
        //         {
        //             holidaysOfColaborator.Add(holiday);
        //         }
        //     }

        //     return holidaysOfColaborator;
        // }

        public List<IHoliday> GetHolidaysByColaborator(IColaborator colaborator)
        {
            return _holidays.Where(holiday => holiday.GetColaborator() == colaborator).ToList();
        }

        // public List<IColaborator> GetColaboratorWithMoreThen(int XDays){
        //     List<IColaborator> colaboratorsWithMoreThanXDays = new List<IColaborator>();
        //     foreach(var holiday in _holidays)
        //     {
        //         foreach (var period in holiday.GetHolidayPeriods())
        //         {
        //             DateTime endDateTime = period._endDate.ToDateTime(TimeOnly.Parse("10:00PM"));
        //             DateTime startDateTime = period._startDate.ToDateTime(TimeOnly.Parse("10:00PM"));
        //             TimeSpan difference = endDateTime.Subtract(startDateTime);
		//             int numberOfDays = difference.Days;
        //             if (numberOfDays > XDays)
        //             {
        //                 colaboratorsWithMoreThanXDays.Add(holiday.GetColaborator());
        //             }
        //         }
        //     }
        //     return colaboratorsWithMoreThanXDays;
        // }

        // public bool IsColaboratorInProject(IColaborator colaborator, IProject project)
        //     {
        //         List<IAssociate> projectAssociations = project.GetAssociations();

        //         foreach (IAssociate associate in projectAssociations)
        //         {
        //             if (associate.Colaborator == colaborator)
        //             {
        //                 return true;
        //             }
        //         }

        //         return false;
        //     }




        // public int GetDaysOfHolidayFromProjectOfColaborator(DateOnly dateStart, DateOnly dateEnd, IColaborator colaborator, IProject project)
        // {
        //     int result = 0;
        //     DateOnly projectStartDate = project._dateStart > dateStart ? project._dateStart : dateStart;
        //     DateOnly projectEndDate =  project._dateEnd < dateEnd ? project._dateEnd : dateEnd;

        //     bool isInProject = IsColaboratorInProject(colaborator, project);
        //     List<IHoliday> holidayList = GetHolidaysOfColaborator(colaborator);

        //     if (isInProject)
        //     {
                
        //         if ( projectEndDate >= project._dateStart || projectStartDate <= project._dateEnd)
        //         {
        //             foreach (var holiday in holidayList)
        //             {  

        //                 foreach (var period in holiday.GetHolidayPeriods())
        //                 {
        //                     // Check if the holiday period intersects with the specified period
        //                     if (period._endDate >= project._dateStart || period._startDate <= project._dateEnd)
        //                     {
        //                         // Calculate the number of days within the intersection
        //                         DateTime intersectionStartDate = period._startDate.ToDateTime(TimeOnly.Parse("10:00PM"));
        //                         DateTime intersectionEndDate = period._endDate.ToDateTime(TimeOnly.Parse("10:00PM"));
        //                         int daysInIntersection = (intersectionEndDate - intersectionStartDate).Days + 1;


        //                         result += daysInIntersection;
        //                     }
        //                 }
    
        //             }
                    
        //         }
        //     }
            
        //     return result;
        // }

        // public int GetDaysOfHolidayFromProjectOfAll(DateOnly DateStart, DateOnly DateEnd, IProject project)
        // {
        //     int totalResult = 0;
        //     DateOnly projectStartDate = project._dateStart > DateStart ? project._dateStart : DateStart;
        //     DateOnly projectEndDate =  project._dateEnd < DateEnd ? project._dateEnd : DateEnd;

        //     List<IColaborator> colaborators = project.GetAssociations().Select(a => a.Colaborator).ToList();
        //     foreach (IColaborator colaborator in colaborators)
        //     {
        //         List<IHoliday> holidayList = GetHolidaysOfColaborator(colaborator);

        //         foreach (var holiday in holidayList)
        //         {
        //             foreach (var period in holiday.GetHolidayPeriods())
        //             {
        //                 DateOnly periodStart = period._startDate > projectStartDate ? period._startDate : projectStartDate;
        //                 DateOnly periodEnd = period._endDate < projectEndDate ? period._endDate : projectEndDate;
        //                 // Check if the holiday period intersects with the specified period
        //                 if (periodStart <= periodEnd)
        //                 {
        //                     // Calculate the number of days within the intersection

        //                     int daysInIntersection = (periodEnd.ToDateTime(TimeOnly.Parse("10:00PM")) - periodStart.ToDateTime(TimeOnly.Parse("10:00PM"))).Days + 1;

        //                     totalResult += daysInIntersection;
        //                 }
        //             }
        //         }    
        //     }
        //     return totalResult;
        // }


    }
}