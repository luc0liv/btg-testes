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
            switch(Estado)
            {
                case "RJ":
                    return PrecoSemImpostos * (decimal)1.15;
                case "MG":
                    return PrecoSemImpostos * (decimal)1.07;
                case "SP":
                case "ES":
                    return PrecoSemImpostos * (decimal)1.12;     
                case "MS":
                    return PrecoSemImpostos * (decimal)1.08;
                case "SC":
                    return PrecoSemImpostos * (decimal)1.18;
                default:
                    throw new ArgumentException("Estado inválido!");
            }
        }
    }
}
