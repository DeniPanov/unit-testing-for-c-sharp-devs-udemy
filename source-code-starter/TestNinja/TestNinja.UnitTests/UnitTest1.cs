using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    public class ReservationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanBeCanceledBy_UserIsAdmin_ReturnsTrue()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy( new User { IsAdmin = true });

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCanceledBy_SameUser_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user};

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCanceledBy_AnotherUser_ReturnsFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy( new User());

            Assert.IsFalse(result);
        }
    }
}
