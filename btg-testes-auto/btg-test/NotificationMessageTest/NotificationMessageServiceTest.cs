using btg_testes_auto.NotificationMessage;
using FluentAssertions;
using NSubstitute;


namespace btg_test.NotificationEmailTest
{
    public class NotificationMessageServiceTest
    {
        private readonly IMessageService _mockMessageService;
        private NotificationService _sut;

        public NotificationMessageServiceTest()
        {
            _mockMessageService = Substitute.For<IMessageService>();
            _sut = new(_mockMessageService);
        }

        [Fact]
        public void NotifyUsers_ReturnsTrue()
        {
            Notification notification1 = new()
            {
                Message = "Messagem 1",
                UserId = "1"
            };
            Notification notification2 = new()
            {
                Message = "Messagem 1",
                UserId = "1"
            };

            List<Notification> notifications = new() 
            { notification1, notification2 };

            _mockMessageService.SendMessage(notification1.UserId, notification1.Message)
                .Returns(true);

            var result = _sut.NotifyUsers(notifications);
            result.Should().BeTrue();
            _mockMessageService.Received().SendMessage(Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void NotifyUsers_ReturnsFalse()
        {
            Notification notification1 = new()
            {
                Message = "Messagem 1",
                UserId = "1"
            };
            Notification notification2 = new()
            {
                Message = "Messagem 1",
                UserId = "1"
            };

            List<Notification> notifications = new()
            { notification1, notification2 };

            _mockMessageService.SendMessage(notification1.UserId, notification1.Message)
                .Returns(false);

            var result = _sut.NotifyUsers(notifications);
            result.Should().BeFalse();
            _mockMessageService.Received().SendMessage(Arg.Any<string>(), Arg.Any<string>());
        }
    }
}
