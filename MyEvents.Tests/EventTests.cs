using Xunit;
using MyEvents;

namespace MyEvents.Tests
{
    public class EventTests
    {
        [Fact]
        public void Event_IsActive_WhenCreated()
        {
            var evnt = new Event("Code Workshop", "Workshop", 50);
            Assert.True(evnt.IsActive);
        }

        [Fact]
        public void CancelEvent_SetsIsActiveToFalse()
        {
            var evnt = new Event("Code Workshop", "Workshop", 50);
            evnt.Cancel();
            Assert.False(evnt.IsActive);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        public void RegisterAttendee_DecreasesCapacity(int initialCapacity)
        {
            var evnt = new Event("Code Workshop", "Workshop", initialCapacity);
            bool registrationResult = evnt.RegisterAttendee();

            Assert.True(registrationResult);
            Assert.Equal(initialCapacity - 1, evnt.Capacity);
        }

        [Fact]
        public void RegisterAttendee_ReturnsFalse_WhenEventIsFull()
        {
            var evnt = new Event("Code Workshop", "Workshop", 0); // Event is already full
            bool registrationResult = evnt.RegisterAttendee();
            Assert.False(registrationResult);
        }

        [Fact]
        public void AverageRating_ReturnsCorrectAverage_WhenRatingsAreAdded()
        {
            // Arrange
            var evnt = new Event("Test Event", "Workshop", 10);
            evnt.AddRating(3);
            evnt.AddRating(4);
            evnt.AddRating(5);

            double averageRating = evnt.AverageRating();

            Assert.Equal(4, averageRating);
        }

        [Fact]
        public void AddRating_ReturnsFalse_WhenRatingIsOutOfRange()
        {
            var evnt = new Event("Test Event", "Workshop", 10);

            bool result = evnt.AddRating(6);

            Assert.False(result);
        }
    }
}