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
        /// Get point of interest by id.
        /// </summary>
        /// <param name="id">Search by this id.</param>
        /// <returns>Found point of interest or null.</returns>
        PointOfInterest GetById(long id);

        /// <summary>
        /// Add a new point of interest to repository.
        /// </summary>
        /// <param name="pointOfInterest">New point of interest.</param>
        /// <returns>New point of interest with new id.</returns>
        PointOfInterest Add(PointOfInterest pointOfInterest);
    }
}
