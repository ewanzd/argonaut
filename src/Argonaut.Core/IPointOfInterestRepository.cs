using System.Collections.Generic;
using System.Linq;

namespace Argonaut.Core
{
    public interface IPointOfInterestRepository
    {
        IEnumerable<PointOfInterest> GetAll();

        PointOfInterest Add(PointOfInterest pointOfInterest);

        void Save();
    }
}
