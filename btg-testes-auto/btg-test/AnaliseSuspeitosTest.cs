using btg_testes_auto;

namespace btg_test
{
    public class AnaliseSuspeitosTest
    {
        [Theory]
        [InlineData(false, false, false, false, false)]
        [InlineData(true, false, false, false, false)]
        [InlineData(false, true, false, false, false)]
        public void ExecutarQuestionarioSuspeito_Inocente(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            AnaliseSuspeitos analise = new();
            var retorno = analise.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);
            Assert.Equal("Inocente", retorno);
        }

        [Theory]
        [InlineData(true, true, false, false, false)]
        [InlineData(true, false, true, false, false)]
        [InlineData(false, false, false, true, true)]
        public void ExecutarQuestionarioSuspeito_Suspeita(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            AnaliseSuspeitos analise = new();
            var retorno = analise.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);
            Assert.Equal("Suspeita", retorno);
        }

        [Theory]
        [InlineData(true, true, true, false, false)]
        [InlineData(true, true, true, true, false)]
        [InlineData(false, true, true, true, true)]
        [InlineData(false, false, true, true, true)]
        public void ExecutarQuestionarioSuspeito_Cumplice(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            AnaliseSuspeitos analise = new();
            var retorno = analise.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);
            Assert.Equal("Cúmplice", retorno);
        }

        [Fact]
        public void ExecutarQuestionarioSuspeito_Assassino()
        {
            AnaliseSuspeitos analise = new();
            var retorno = analise.ExecutarQuestionarioSuspeito(true, true, true, true, true);
            Assert.Equal("Assassino", retorno);
        }

    }
}
