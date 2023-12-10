using btg_testes_auto;

namespace btg_test
{
    public class LucroTest
    {
        [Fact]
        public void CalcularLucro_ValorMenorQueVinte_Lucro45Porcento()
        {
            Lucro lucro = new();
            var retorno = lucro.Calcular(19);
            Assert.Equal(27.55M, retorno);
        }

        [Fact]
        public void CalcularLucro_ValorIgualAVinte_Lucro35Porcento()
        {
            Lucro lucro = new();
            var retorno = lucro.Calcular(20);
            Assert.Equal(26M, retorno);
        }

        [Fact]
        public void CalcularLucro_ValorMaiorQueVinte_Lucro35Porcento()
        {
            Lucro lucro = new();
            var retorno = lucro.Calcular(25);
            Assert.Equal(32.50M, retorno);
        }
    }
}
