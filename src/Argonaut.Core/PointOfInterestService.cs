using System.Collections.Generic;

namespace Argonaut.Core
{
    public class PointOfInterestService : IPointOfInterestService
    {
        private readonly IPointOfInterestRepository _pointOfInterestRepository;

        public PointOfInterestService(IPointOfInterestRepository pointOfInterestRepository)
        {
            _pointOfInterestRepository = pointOfInterestRepository;
        }

        public PointOfInterest CreatePointOfInterest(PointOfInterest pointOfInterest)
        {
            var savedPointOfInterest = _pointOfInterestRepository.Add(pointOfInterest);
            _pointOfInterestRepository.Save();

            return savedPointOfInterest;
        }

        public IEnumerable<PointOfInterest> GetAllPointOfInterests()
        {
            return _pointOfInterestRepository.GetAll();
        }
    }
}
