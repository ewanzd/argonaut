using Argonaut.Core.Logging;
using System.Collections.Generic;

namespace Argonaut.Core
{
    public class PointOfInterestService : IPointOfInterestService
    {
        private readonly ILogger _logger;
        private readonly IPointOfInterestRepository _pointOfInterestRepository;

        public PointOfInterestService(ILoggerFactory loggerFactory, IPointOfInterestRepository pointOfInterestRepository)
        {
            _logger = loggerFactory.Create<PointOfInterestService>();
            _pointOfInterestRepository = pointOfInterestRepository;
        }

        public PointOfInterest CreatePointOfInterest(PointOfInterest pointOfInterest)
        {
            _logger.Debug("try to create new point of interest");

            var savedPointOfInterest = _pointOfInterestRepository.Add(pointOfInterest);
            _pointOfInterestRepository.Save();

            _logger.Debug("new point of interest created");

            return savedPointOfInterest;
        }

        public IEnumerable<PointOfInterest> GetAllPointOfInterests()
        {
            return _pointOfInterestRepository.GetAll();
        }
    }
}
