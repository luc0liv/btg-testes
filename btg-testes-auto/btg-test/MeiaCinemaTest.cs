using btg_testes_auto;

namespace btg_test
{
    public class MeiaCinemaTest
    {
        [Theory]
        [InlineData(true, false, false, false)]
        [InlineData(false, true, false, false)]
        [InlineData(false, false, true, true)]
        public void VerificaSePagaMeia_ReturnsTrue(bool est, bool donor, bool worker, bool contract)
        {
            MeiaCinema meiaCinema = new();
            bool retorno = meiaCinema.VerificarMeiaCinema(est, donor, worker, contract);
            Assert.True(retorno);
        }

        [Theory]
        [InlineData(false, false, false, false)]
        [InlineData(false, false, false, true)]
        [InlineData(false, false, true, false)]
        public void VerificaSeNaoPagaMeia_ReturnsFalse(bool student, bool donor, bool worker, bool contract)
        {
            MeiaCinema meiaCinema = new();
            bool retorno = meiaCinema.VerificarMeiaCinema(student, donor, worker, contract);
            Assert.False(retorno);
        }
    }
}
