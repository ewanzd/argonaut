using System.Collections.Generic;

namespace Argonaut.Core
{
    public interface IPointOfInterestService
    {
        IEnumerable<PointOfInterest> GetAllPointOfInterests();

        PointOfInterest CreatePointOfInterest(PointOfInterest pointOfInterest);
    }
}
