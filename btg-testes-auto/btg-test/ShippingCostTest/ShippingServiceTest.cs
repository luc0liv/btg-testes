using btg_testes_auto.ShippingCost;
using FluentAssertions;
using NSubstitute;
using NSubstitute.Core.Arguments;

namespace btg_test.ShippingCostTest
{
    public class ShippingServiceTest
    {
        private readonly IDeliveryCostCalculator _mockCostCalculator;
        private ShippingService _sut;

        public ShippingServiceTest()
        {
            _mockCostCalculator = Substitute.For<IDeliveryCostCalculator>();
            _sut = new(_mockCostCalculator);
        }

        [Fact]
        public void CalculateShippingCost_ExpressDelivery_50PercentDiscount()
        {
            _mockCostCalculator.CalculateCost(250, DeliveryType.Express)
                .Returns(100);

            var result = _sut.CalculateShippingCost(250, DeliveryType.Express);

            result.Should().Be(50);
        }

        [Fact]
        public void CalculateShippingCost_ExpressDelivery_NoDiscount()
        {
            _mockCostCalculator.CalculateCost(190, DeliveryType.Express)
                .Returns(90);

            var result = _sut.CalculateShippingCost(190, DeliveryType.Express);

            result.Should().Be(90);
        }
    }
}
