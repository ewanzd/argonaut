using System.Collections.Generic;
using System.Linq;

namespace Argonaut.Core
{
    public interface IPointOfInterestRepository
    {
        IQueryable<PointOfInterest> GetAll();

        PointOfInterest Add(PointOfInterest pointOfInterest);

        void Save();
    }
}
