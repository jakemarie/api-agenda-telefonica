using API_listaTelefone.Models;

namespace API_listaTelefone.Service.TelefoneService
{
    public interface ITelefoneService
    {
        Task<ServiceResponse<List<Telefone>>> CreateTelefone(Telefone novoTelefone);
        Task<ServiceResponse<List<Telefone>>> GetTelefone();
        Task<ServiceResponse<Telefone>> GetTelefoneById(int Id);
        Task<ServiceResponse<List<Telefone>>> UpdateTelefone(Telefone editadoTelefone);
        Task<ServiceResponse<List<Telefone>>> DeleteTelefone(int id);
    }
}
