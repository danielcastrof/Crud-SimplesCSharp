using System.Collections.Generic;
using CadastroSeries.Interfaces;
namespace CadastroSeries
{
    public class RepositorioSeries : RepositorioGenerico<Series>
    {
        private List<Series> catalogo = new List<Series>();
        public void Atualizar(int id, Series objt)
        {
            catalogo[id] = objt;
        }

        public void Excluir(int id)
        {
            catalogo[id].setExcluido();
        }

        public void Inserir(Series objt)
        {
            catalogo.Add(objt);
        }

        public List<Series> Listar()
        {
            return catalogo;
        }

        public Series RetornoID(int id)
        {
            return catalogo[id];
        }

        public int NextId()
        {
            return catalogo.Count;
        }
    }
}