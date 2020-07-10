using System;
using Argonaut.Core;
using Argonaut.Core.Logging;
using Moq;
using Xunit;

namespace Argonaut.Services.Tests
{
    public class PointOfInterestServiceTest
    {
        [Fact]
        public void GetPointOfInterestById_GetById_IsSameId()
        {
            var logger = new Mock<ILogger>();
            var loggerFactory = new Mock<ILoggerFactory>();
            loggerFactory
                .Setup(x => x.Create<PointOfInterestService>())
                .Returns(logger.Object);

            var persistenceContext = new Mock<IPersistenceContext>();

            var pointOfInterestRepository = new Mock<IPointOfInterestRepository>();
            pointOfInterestRepository
                .Setup(x => x.GetById(It.IsAny<long>()))
                .Returns<long>(x => new PointOfInterest(x, "abc", "def", new Coordinate(0, 0)));

            var pointOfInterestService = new PointOfInterestService(loggerFactory.Object, persistenceContext.Object, pointOfInterestRepository.Object);

            var foundPointOfInterest = pointOfInterestService.GetPointOfInterestById(5);

            Assert.Equal(5, foundPointOfInterest.PointOfInterestId);
        }
    }
}
