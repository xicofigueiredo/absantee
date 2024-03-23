using System.Dynamic;
using System.Net;

namespace Domain;

public class HolidayPeriod
{
	private DateOnly _startDate;
	private DateOnly _endDate;

	public HolidayPeriod(DateOnly startDate, DateOnly endDate)
	{
		if( startDate <= endDate ) {
			_startDate = startDate;
			_endDate = endDate;
		}
		else
			throw new ArgumentException("invalid arguments: start date > end date.");
	}

	public int getNumberOfDays() {
		return (_endDate.ToDateTime(TimeOnly.MinValue) - _startDate.ToDateTime(TimeOnly.MinValue)).Days + 1;
	}

	public DateOnly getStartDate() {
		return _startDate;
	}

	public DateOnly getEndDate() {
		return _endDate;
	}
}

