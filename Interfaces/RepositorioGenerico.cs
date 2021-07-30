using System.Collections.Generic;
namespace CadastroSeries.Interfaces
{
    public interface RepositorioGenerico<T>
    {
        List<T> Listar();
        T RetornoID(int id);
        void Inserir(T objt);
        void Excluir(int id);
        void Atualizar(int id, T objt);

        int NextId();


    }
}