using API_listaTelefone.Models;

namespace API_listaTelefone.Service.PessoaService
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> GetPessoa();
        Task<ServiceResponse<List<Pessoa>>> CreatePessoa(Pessoa novoFuncionario);
        Task<ServiceResponse<Pessoa>> GetPessoaById(int Id);


    }
}
