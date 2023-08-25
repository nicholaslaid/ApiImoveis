namespace ApiImoveis.Models
{
    public class Imoveis
    {
        public int id { get; set; }
        public string cidade { get; set; }

        public string bairro { get; set; }

        public string type { get; set; }

        public float value { get; set; }

        public int qtd_de_quartos { get; set; }

        public int qtd_de_banheiros { get; set; }

        public int qtd_de_salas { get; set; }

        public int qtd_de_vagas { get; set; }

    }
}
