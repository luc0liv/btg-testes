using btg_testes_auto;
using FluentAssertions;

namespace btg_test
{
    public class VooTest
    {
        [Fact]
        public void ProximoLivre_SemVagasDisponiveis_RetornaZero()
        {
            Voo voo = new("avião", "1234", DateTime.Now);
            var retorno = voo.ProximoLivre();
            retorno.Should().Be(0);
        }

        [Fact]
        public void ProximoLivre_ComVagasDisponiveis_RetornaPosicaoDois()
        {
            Voo voo = new("avião", "1234", DateTime.Now);
            voo.OcupaAssento(0);
            voo.OcupaAssento(1);
            var retorno = voo.ProximoLivre();
            retorno.Should().Be(2);
        }

        [Fact]
        public void ExibeInfoVoo_RetornaAeronaveENumeroVoo()
        {
            Voo voo = new("avião", "1234", DateTime.Now);
            var retorno = voo.ExibeInformacoesVoo();
            retorno.Should().Be($"Aeronave avião registrada sob voo de número 1234 para o dia e hora {DateTime.Now}");
        }

        [Fact]
        public void AssentoDisponivel_RetornaTrue()
        {
            Voo voo = new("avião", "1234", DateTime.Now);
            voo.OcupaAssento(1);
            var retorno = voo.AssentoDisponivel(2);
            retorno.Should().BeTrue();
        }

        [Fact]
        public void AssentoDisponivel_RetornaFalse()
        {
            Voo voo = new("avião", "1234", DateTime.Now);
            voo.OcupaAssento(1);
            var retorno = voo.AssentoDisponivel(1);
            retorno.Should().BeFalse();
        }

        [Fact]
        public void QuantidadeVagasDisponivel_Retorna99()
        {
            Voo voo = new("avião", "1234", DateTime.Now);
            voo.OcupaAssento(0);
            var retorno = voo.QuantidadeVagasDisponivel();
            retorno.Should().Be(99);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void OcupaAssento_RetornaFalse(int posicao)
        {
            Voo voo = new("avião", "1234", DateTime.Now);
            voo.OcupaAssento(posicao);
            var retorno = voo.OcupaAssento(posicao);
            retorno.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void OcupaAssento_RetornaTrue(int posicao)
        {
            Voo voo = new("avião", "1234", DateTime.Now);
            var retorno = voo.OcupaAssento(posicao);
            retorno.Should().BeTrue();
        }
    }

}
