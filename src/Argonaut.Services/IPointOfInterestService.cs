using System.Collections.Generic;
using Argonaut.Core;

namespace Argonaut.Services
{
    public interface IPointOfInterestService
    {
        IEnumerable<PointOfInterest> GetAllPointOfInterests();

        PointOfInterest GetPointOfInterestById(long id);

        PointOfInterest CreatePointOfInterest(PointOfInterest pointOfInterest);
    }
}
