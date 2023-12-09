namespace btg_testes_auto
{
    public class ImpostoProduto
    {
        public decimal PrecoSemImpostos { get; set; }
        public string Estado { get; set; }

        public ImpostoProduto(decimal preco, string estado)
        {
            PrecoSemImpostos = preco;
            Estado = estado;
        }
        public decimal PrecoFinalProduto()
        {
            if (Estado == "RJ")
            {
                return PrecoSemImpostos * (decimal)1.15;
            }
            if  (Estado == "MG")
            {
                return PrecoSemImpostos * (decimal)1.07;
            }
            if (Estado == "SP" || Estado == "ES")
            {
                return PrecoSemImpostos * (decimal)1.12;
            }
            if (Estado == "MS")
            {
                return PrecoSemImpostos * (decimal)1.08;
            }
            if (Estado == "SC")
            {
                return PrecoSemImpostos * (decimal)1.18;
            } 

         throw new Exception("Estado inválido!");
        }
    }
}
