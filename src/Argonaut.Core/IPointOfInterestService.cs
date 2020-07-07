using System.Collections.Generic;

namespace Argonaut.Core
{
    public interface IPointOfInterestService
    {
        IEnumerable<PointOfInterest> GetAllPointOfInterests();

        PointOfInterest GetPointOfInterestById(long id);

        PointOfInterest CreatePointOfInterest(PointOfInterest pointOfInterest);
    }
}
