using Argonaut.Core.Logging;
using System.Collections.Generic;

namespace Argonaut.Core
{
    public class PointOfInterestService : IPointOfInterestService
    {
        private readonly ILogger _logger;
        private readonly ISaveService _saveService;
        private readonly IPointOfInterestRepository _pointOfInterestRepository;

        public PointOfInterestService(ILoggerFactory loggerFactory, ISaveService saveService, IPointOfInterestRepository pointOfInterestRepository)
        {
            _logger = loggerFactory.Create<PointOfInterestService>();
            _saveService = saveService;
            _pointOfInterestRepository = pointOfInterestRepository;
        }

        public PointOfInterest CreatePointOfInterest(PointOfInterest pointOfInterest)
        {
            _logger.Debug("try to create new point of interest");

            var savedPointOfInterest = _pointOfInterestRepository.Add(pointOfInterest);
            _saveService.SaveChanges();

            _logger.Debug("new point of interest created");

            return savedPointOfInterest;
        }

        public IEnumerable<PointOfInterest> GetAllPointOfInterests()
        {
            return _pointOfInterestRepository.GetAll();
        }
    }
}
