using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Training
    {

        public IColaborator _colaborator;

	    public List<TrainingPeriod> _trainingPeriods = new List<TrainingPeriod>();
        public string Description;
        private IColaborator @object;

        public Training(string description, IColaborator colab)
        {
            if(colab!=null && isValidDescription(description))
            {
                 _colaborator = colab;
                this.Description = description;
            }
		    else
			    throw new ArgumentException("Invalid argument");
        }

        public Training(IColaborator @object)
        {
            this.@object = @object;
        }

        private bool isValidDescription(string description)
        {
            return !string.IsNullOrWhiteSpace(description);
        }

        public TrainingPeriod addTrainingPeriod(DateOnly startDate, DateOnly endDate) {

		var trainingPeriod = new TrainingPeriod(startDate, endDate);
		_trainingPeriods.Add(trainingPeriod);
		 return trainingPeriod;
	    }
    }

}