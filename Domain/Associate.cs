using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Associate : IAssociate
    {
        private IColaborator colaborator;
        private IProject Project;
        public DateOnly DateStart { get; private set; }
        public DateOnly DateEnd{ get; private set; }
 
        public Associate( IColaborator Colaborator, IProject project, DateOnly dateStart, DateOnly dateEnd ){
 
            colaborator = Colaborator ?? throw new ArgumentNullException(nameof(Colaborator));
            Project = project ?? throw new ArgumentNullException(nameof(project));
            DateStart = dateStart;
            DateEnd = dateEnd;
        }
 
        public IColaborator Colaborator
        {
        get { return colaborator; }
        }
 
 
 
        public (IColaborator, IProject, DateOnly, DateOnly) GetAssociation()
        {
            return (colaborator, Project, DateStart, DateEnd);
        }
    }
}

