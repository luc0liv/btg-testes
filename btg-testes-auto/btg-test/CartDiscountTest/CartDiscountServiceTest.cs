using btg_testes_auto.CartDiscount;
using FluentAssertions;
using NSubstitute;

namespace btg_test.CartDiscountTest
{
    public class CartDiscountServiceTest
    {
        private readonly IDiscountService _mockDiscountService;
        private CartService _sut;

        public CartDiscountServiceTest()
        {
            _mockDiscountService = Substitute.For<IDiscountService>();
            _sut = new(_mockDiscountService);
        }

        [Fact]
        public void CalculateTotalWithDiscount_ReturnTotal()
        {
            CartItem cartItem1 = new ()
            {
                Price = 100,
                ProductId = "id123"
            };

            CartItem cartItem2 = new ()
            {
                Price = 250,
                ProductId = "id231"
            };

            List<CartItem> cartItems = new () { cartItem1, cartItem2 };

            _mockDiscountService.CalculateDiscount(cartItems).Returns(60);

            double result = _sut.CalculateTotalWithDiscount(cartItems);

            result.Should().Be(290);
            _mockDiscountService.Received().CalculateDiscount(cartItems);
        }

    }
}
