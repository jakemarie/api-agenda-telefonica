using API_listaTelefone.Models;

namespace API_listaTelefone.Service.PessoaService
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> GetPessoa();
    }
}
