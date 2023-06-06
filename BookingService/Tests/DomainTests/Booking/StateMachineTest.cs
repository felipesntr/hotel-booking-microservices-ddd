using Domain.Entities;
using Domain.Enums;

namespace DomainTests.Bookings
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Pay);

            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Paid));
        }

        [Test]
        public void ShouldSetStatusToCanceledWhenCancelingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Cancel);

            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Canceled));
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Pay);
            booking.ChangeState(Domain.Enums.Action.Finish);

            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Finished));
        }

        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundingABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Pay);
            booking.ChangeState(Domain.Enums.Action.Refound);

            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Refounded));
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenReopenACanceledBooking()
        {
            var booking = new Booking();
            booking.ChangeState(Domain.Enums.Action.Cancel);
            booking.ChangeState(Domain.Enums.Action.Reopen);

            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
        }
    }
}