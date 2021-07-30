namespace CadastroSeries
{
    public class Series : ClasseBase
    {
        //Atributos das séries
        private string nome { get; set; } // Referência ao nome/título da série.
        private Genero genero { get; set; } // Referência ao gênero da série.
        private string descricao { get; set; } // Texto breve sobre a série.
        private double ano { get; set; } // Ano de lançamento da série.
        private Atividade atividade { get; set; } // Retorna se a série já foi encerrada.
        private bool excluido { get; set; } // revela se a série foi exluída.

        public enum Atividade
        {
            Sim = 1,
            Nao = 2
        }

        public enum Genero
        {
            Terror = 1,
            Suspense = 2,
            Aventura = 3,
            Acao = 4,
            Heroes = 5,
            Romance = 6,
            Fatos_Reais = 7,
            Ficcao = 8,
            Drama = 9,
            Comedia = 10,
            Kids = 11,
            BR = 12
        }

        public Series(int Id, string nome, Genero genero, string descricao, double ano, Atividade atividade)
        { // Construtor da classe
            this.Id = Id;
            this.nome = nome;
            this.genero = genero;
            this.descricao = descricao;
            this.ano = ano;
            this.atividade = atividade;
            this.excluido = false;
        }

        public string getNome()
        {
            return this.nome;
        }

        public int getId()
        {
            return this.Id;
        }

        public void setExcluido()
        {
            this.excluido = true;
        }

        public bool getExcluido()
        {
            return this.excluido;
        }



        public override string ToString() // Retorna uma String com informações relevantes dos atributos do objeto
        {
            return "Título: " + this.nome + "\n" + "Gênero: " + this.genero + "\n" + "Resumo: " + this.descricao + "\n" + "Ano de Lançamento: " + this.ano + "\n" + "Em atividade: " + atividade;
        }

    }
}