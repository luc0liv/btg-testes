using btg_testes_auto.Notification;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace btg_test.NotificationEmailTest
{
    public class NoticationServiceTest
    {
        private readonly IEmailService _mockEmailService;
        private NotificationService _sut;

        public NoticationServiceTest()
        {
            _mockEmailService = Substitute.For<IEmailService>();
            _sut = new(_mockEmailService);
        }

        [Theory]
        [InlineData("Maria", "Messagem")]
        [InlineData("Luciana", "Messagem Dois")]
        [InlineData("Luciana", "M")]
        public void SendNotification_ValidRecipient_ReturnsTrue(string recipient, string message)
        {
            _mockEmailService.SendEmail(recipient,"Notification", message).Returns(true);
            var result = _sut.SendNotification(recipient, message);
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("Maria", "")]
        [InlineData("Luciana", null)]
        public void SendNotification_InvalidRecipient_ReturnsFalse(string recipient, string message)
        {
            _mockEmailService.SendEmail(recipient, "Notification", message).Returns(false);
            var result = _sut.SendNotification(recipient, message);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("", "message")]
        [InlineData(null, "message")]
        public void SendNotification_InvalidRecipient_ThrowsException(string recipient, string message)
        {
            _mockEmailService.SendEmail(recipient, "Notification", message).ThrowsForAnyArgs(new Exception());
            var result = _sut.SendNotification(recipient, message);
            result.Should().BeFalse();
        }
    }
}
