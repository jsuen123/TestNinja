using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        Mock<IBookingRepository> _bookingRepository;
        private Booking _existingBooking;

        [SetUp]
        public void Setup()
        {
            _bookingRepository = new Mock<IBookingRepository>();
            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"
            };
        }

        [Test]
        public void OverlappingBookingsExist_StatusIsCancelled_ReturnEmptyString()
        {
            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Status = "Cancelled" }, _bookingRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingExist_BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {

            _bookingRepository.Setup(m => m.GetActiveBookings(It.IsAny<int>())).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate),
            }, _bookingRepository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingExist_BookingStartsBeforeAndFinishedsInTheMiddleOfAnExistingBooking_ReturnExistingBooking()
        {

            _bookingRepository.Setup(m => m.GetActiveBookings(It.IsAny<int>())).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.ArrivalDate),
            }, _bookingRepository.Object);

            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
