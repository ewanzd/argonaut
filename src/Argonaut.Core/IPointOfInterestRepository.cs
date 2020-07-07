using System.Linq;

namespace Argonaut.Core
{
    public interface IPointOfInterestRepository
    {
        /// <summary>
        /// Get all existing point of interests.
        /// </summary>
        /// <returns></returns>
        IQueryable<PointOfInterest> GetAll();

        /// <summary>
        /// Add a new point of interest to repository.
        /// </summary>
        /// <param name="pointOfInterest">New point of interest.</param>
        /// <returns>New point of interest with new id.</returns>
        PointOfInterest Add(PointOfInterest pointOfInterest);
    }
}
