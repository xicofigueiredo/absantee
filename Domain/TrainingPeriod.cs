using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class TrainingPeriod
    {
        public DateOnly _startDate;
        public DateOnly _endDate;

        public TrainingPeriod(DateOnly startDate, DateOnly endDate)
        {
            if( startDate < endDate ) {
                _startDate = startDate;
                _endDate = endDate;
            }
            else
                throw new ArgumentException("invalid arguments: start date >= end date.");
        }
    }
}