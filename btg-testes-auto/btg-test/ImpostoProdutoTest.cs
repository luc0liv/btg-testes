using btg_testes_auto;

namespace btg_test
{
    /* ImpostoProduto
* Uma empresa vende o mesmo produto para diferentes estados.
* Cada estado possui uma taxa diferente de imposto sobre o produto
* (MG 7%; SP 12%; RJ 15%; MS 8%; ES 12%; SC 18%;).
* Faça um programa que retorne o preço final do produto acrescido do imposto do estado em que ele será vendido.
* Se o estado digitado não for válido, estoure uma exception.
*/
    public class ImpostoProdutoTest
    {
        [Fact]
        public void PrecoFinalProduto_RJ()
        {
            ImpostoProduto imposto = new(100, "RJ");
            var result = imposto.PrecoFinalProduto();
            Assert.Equal(115, result);
        }

        [Fact]
        public void PrecoFinalProduto_MG()
        {
            ImpostoProduto imposto = new(100, "MG");
            var result = imposto.PrecoFinalProduto();
            Assert.Equal(107, result);
        }

        [Fact]
        public void PrecoFinalProduto_SP()
        {
            ImpostoProduto imposto = new(100, "SP");
            var result = imposto.PrecoFinalProduto();
            Assert.Equal(112, result);
        }

        [Fact]
        public void PrecoFinalProduto_ES()
        {
            ImpostoProduto imposto = new(100, "ES");
            var result = imposto.PrecoFinalProduto();
            Assert.Equal(112, result);
        }

        [Fact]
        public void PrecoFinalProduto_MS()
        {
            ImpostoProduto imposto = new(100, "MS");
            var result = imposto.PrecoFinalProduto();
            Assert.Equal(108, result);
        }

        [Fact]
        public void PrecoFinalProduto_SC()
        {
            ImpostoProduto imposto = new(100, "SC");
            var result = imposto.PrecoFinalProduto();
            Assert.Equal(118, result);
        }

        [Fact]
        public void PrecoFinalProduto_EstadoInvalido_LancaException()
        {
            ImpostoProduto imposto = new(100, "XX");
            Action act = () => imposto.PrecoFinalProduto();
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal("Estado inválido!", exception.Message);
        }
    }
}
