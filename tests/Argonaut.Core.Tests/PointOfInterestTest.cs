using Xunit;

namespace Argonaut.Core.Tests
{
    public class PointOfInterestTest
    {
        [Fact]
        public void SetId_OfNewPointOfInterest_ReturnNewInstance()
        {
            var poi = new PointOfInterest("abc", "def", new Coordinate(0, 0));

            Assert.Equal(0, poi.PointOfInterestId);

            var newPoi = poi.SetId(1);

            Assert.Equal(0, poi.PointOfInterestId);
            Assert.Equal(1, newPoi.PointOfInterestId);
        }
    }
}
