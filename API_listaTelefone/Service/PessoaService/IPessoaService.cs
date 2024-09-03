using API_listaTelefone.Models;

namespace API_listaTelefone.Service.PessoaService
{
    public interface IPessoaService
    {
        Task<ServiceResponse<List<Pessoa>>> GetPessoa();
        Task<ServiceResponse<List<Pessoa>>> CreatePessoa(Pessoa novoPessoa);
        Task<ServiceResponse<Pessoa>> GetPessoaById(int Id);
        Task<ServiceResponse<List<Pessoa>>> DeletePessoa(int id);
        Task<ServiceResponse<List<Pessoa>>> UpdatePessoa(Pessoa editadoPessoa);

    }
}
