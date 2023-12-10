using btg_testes_auto;

namespace btg_test
{
    public class MotoristaTest
    {
        Pessoa pessoa1 = new()
        {
            Nome = "Fulano",
            Idade = 20,
            PossuiHabilitaçãoB = true,
        };
        Pessoa pessoa2 = new()
        {
            Nome = "Ciclano",
            Idade = 26,
            PossuiHabilitaçãoB = true,
        };
        Pessoa pessoa3 = new()
        {
            Nome = "Beltrano",
            Idade = 17,
            PossuiHabilitaçãoB = false,
        };
        Pessoa pessoa4 = new()
        {
            Nome = "Fulana",
            Idade = 18,
            PossuiHabilitaçãoB = false,
        };

        [Fact]
        public void EncontrarMotoristas_MotoristasEncontrados_RetornaMensagemComNomesDeMotorista()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(pessoa1);
            pessoas.Add(pessoa2);
            pessoas.Add(pessoa3);
            pessoas.Add(pessoa4);

            Motorista motorista = new();
            string retorno = motorista.EncontrarMotoristas(pessoas);
            Assert.Equal($"Uhuu! Os motorista são {pessoas[0].Nome} e {pessoas[1].Nome}", retorno);
        }

        [Fact]
        public void EncontrarMotoristas_SemMotoristasDisponiveis_LancaException()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(pessoa3);
            pessoas.Add(pessoa4);

            Motorista motorista = new();
            
            Action act = () => motorista.EncontrarMotoristas(pessoas);
            var exception = Assert.Throws<Exception>(act);

            Assert.Equal("A viagem não será realizada devido falta de motoristas!", exception.Message);
        }
    }
}
