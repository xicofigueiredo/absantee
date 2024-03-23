using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class Project : IProject
  {
    public string? _strName;

    public DateOnly _dateStart;

    public DateOnly? _dateEnd;

    private List<Associate> _associates = new List<Associate>();


    public Project(string _strName, DateOnly _dateStart, DateOnly? _dateEnd)
      {
        if( _dateStart > _dateEnd &&
          _strName!=null &&
          _strName.Length <= 50 &&
          !ContainsAny(_strName, ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"])) {
          this._strName = _strName;
          this._dateStart = _dateStart;
          this._dateEnd = _dateEnd;
          }
        
    }

    public void AddAssociate(Associate associate)
      {
          if (associate != null)
          {
              _associates.Add(associate);
          }
      }

      // public int GetTotalHolidaysForAllColaborators(DateOnly startDate, DateOnly endDate)
      // {
      //     return _associates.Sum(associate => associate.Colaborator.GetTotalHolidayDaysInPeriod(startDate, endDate));
      // }

      private bool ContainsAny(string stringToCheck, params string[] parameters)
      {
        return parameters.Any(parameter => stringToCheck.Contains(parameter));
      }

      public DateOnly? GetStartDate() {
        return _dateStart;
      }

      public DateOnly? GetEndDate() {
        return _dateEnd;
      }

  }
}