using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
 
namespace Domain
{
    public class Opinion
    {
        public DateTime Date;
        public DecisionType Decision;
        public string Description;
        public Colaborator colaborator;    
       
        public Opinion(DateTime date, DecisionType decision, string description, Colaborator colaborator){
       
                Date = date;
                Decision = decision;
                Description = string.IsNullOrEmpty(description) ? throw new ArgumentNullException(nameof(description)) : description;
                this.colaborator = colaborator ?? throw new ArgumentNullException(nameof(colaborator));
        }
 
        public enum DecisionType{
            Accepted,
            Denyed
        }
    }
}
