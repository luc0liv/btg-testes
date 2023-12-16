using btg_testes_auto.Discount;
using FluentAssertions;
using NSubstitute;

namespace btg_test.ClientDiscountTest
{
    public class DiscountServiceTest
    {
        private readonly ICustomerService _mockCustomerService;
        private DiscountService _sut;

        public DiscountServiceTest()
        {
            _mockCustomerService = Substitute.For<ICustomerService>();
            _sut = new(_mockCustomerService);
        }

        [Fact]
        public void GetDiscount_RegularCustomer_5PercentDiscount()
        {
            _mockCustomerService.GetCustomerType(1)
                .Returns(CustomerType.Regular);
            var result = _sut.GetDiscount(1, 250);
            result.Should().Be(12.5);
        }

        [Fact]
        public void GetDiscount_PremiumCustomer_10PercentDiscount()
        {
            _mockCustomerService.GetCustomerType(2)
                .Returns(CustomerType.Premium);
            var result = _sut.GetDiscount(2, 250);
            result.Should().Be(25);
        }

        [Fact]
        public void GetDiscount_OtherCustomers_NoDiscount()
        {
            _mockCustomerService.GetCustomerType(Arg.Any<int>()).Returns((CustomerType)100);
            var result = _sut.GetDiscount(3, 250);
            result.Should().Be(0);
        }

    }
}
