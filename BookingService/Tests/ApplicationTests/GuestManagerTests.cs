using Application;
using Application.Guest.DTO;
using Application.Guest.Requests;
using Domain.Entities;
using Domain.Ports;
using Moq;

namespace ApplicationTests
{
    public class Tests
    {
        GuestManager guestManager;

        [SetUp]
        public void Setup() { }

        [Test]
        public async Task HappyPath()
        {
            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Save(It.IsAny<Guest>())).Returns(Task.FromResult(222));
            guestManager = new GuestManager(fakeRepo.Object);

            var guestDto = new GuestDTO()
            {
                Name = "Fulano",
                Surname = "Hungria",
                Email = "hungria@email.com",
                IdNumber = "asds",
                IdTypeCode = 1
            };

            var request = new CreateGuestRequest()
            {
                Data = guestDto
            };

            var response = await guestManager.CreateGuest(request);

            Assert.IsNotNull(response);
            Assert.True(response.Success);
            Assert.That(response.Data.Id, Is.EqualTo(222));
        }

        [TestCase("a")]
        [TestCase("c")]
        [TestCase("cb")]
        [TestCase("abc")]
        [TestCase(null)]
        public async Task Should_Return_InvalidPersonDocumentIdException_WhenDocsAreInvalid(string docNumber)
        {
            var fakeRepo = new Mock<IGuestRepository>();
            fakeRepo.Setup(x => x.Save(It.IsAny<Guest>())).Returns(Task.FromResult(222));
            guestManager = new GuestManager(fakeRepo.Object);

            var guestDto = new GuestDTO()
            {
                Name = "Fulano",
                Surname = "Hungria",
                Email = "hungria@email.com",
                IdNumber = docNumber,
                IdTypeCode = 1

            };
            var request = new CreateGuestRequest()
            {
                Data = guestDto
            };

            var response = await guestManager.CreateGuest(request);


            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success, Is.False);
            Assert.That(response.ErrorCode, Is.EqualTo(ErrorCodes.INVALID_PERSON_ID));

        }
    }
}