using Cadastro.Parceiros.Domain.Requests;

namespace Cadastro.Parceiros.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task CadastrarCategoria(CadastrarCategoriaRequest1 categoria);

    }
}
