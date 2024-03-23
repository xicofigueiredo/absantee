namespace Domain;

public class Holiday
{
	private IColaborator _colaborator;

	private List<HolidayPeriod> _holidayPeriods;

	public Holiday(IColaborator colab)
	{
		if(colab!=null)
			_colaborator = colab;
		else
			throw new ArgumentException("Invalid argument: colaborator must be non null");

		_holidayPeriods = new List<HolidayPeriod>();
	}
	
	public HolidayPeriod addHolidayPeriod(IHolidayPeriodFactory holidayPeriodFactory, DateOnly startDate, DateOnly endDate) { 

		HolidayPeriod holidayPeriod = holidayPeriodFactory.NewHolidayPeriod(startDate, endDate);
		_holidayPeriods.Add(holidayPeriod);
		 return holidayPeriod;
	}

	public List<HolidayPeriod> getHolidayPeriodsInRange(DateOnly startDate, DateOnly endDate){
        var result = new List<HolidayPeriod>();
        foreach(HolidayPeriod p in _holidayPeriods){
	 		if(p.getStartDate() >= startDate && p.getEndDate() <= endDate){
	 			result.Add(p);
	 		}
	 	}
        return result;
    }

	public int getTotalHolidayDays(List<HolidayPeriod> _holidayPeriods){
 
        int totalDiasFerias = 0;
       
        foreach (HolidayPeriod holidayPeriod in _holidayPeriods){
            int dias = holidayPeriod.getEndDate().DayNumber - holidayPeriod.getStartDate().DayNumber + 1;
            totalDiasFerias += dias;
        }
        return totalDiasFerias;
    }
 

	public IColaborator GetColaborator() {
	   return _colaborator;
	}

}
