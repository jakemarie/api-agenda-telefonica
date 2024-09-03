using API_listaTelefone.DataContext;
using API_listaTelefone.Models;
using Microsoft.EntityFrameworkCore;

namespace API_listaTelefone.Service.TelefoneService
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ApplicationDbContext _context;
        public TelefoneService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Telefone>>> CreateTelefone(Telefone novaTelefone)
        {
            ServiceResponse<List<Telefone>> serviceResponse = new ServiceResponse<List<Telefone>>();
            try
            {
                if (novaTelefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }



                _context.Add(novaTelefone);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Telefone.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<List<Telefone>>> GetTelefone()
        {
            ServiceResponse<List<Telefone>> serviceResponse = new ServiceResponse<List<Telefone>>();
            try
            {

                serviceResponse.Dados = _context.Telefone.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<Telefone>> GetTelefoneById(int id)
        {
            ServiceResponse<Telefone> serviceResponse = new ServiceResponse<Telefone>();
            try
            {
                Telefone telefone = _context.Telefone.FirstOrDefault(x => x.Id == id);

                if (telefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = telefone;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;


        }
        public async Task<ServiceResponse<List<Telefone>>> UpdateTelefone(Telefone editadoPessoa)
        {
            ServiceResponse<List<Telefone>> serviceResponse = new ServiceResponse<List<Telefone>>();

            try
            {
                Telefone pessoa = _context.Telefone.AsNoTracking().FirstOrDefault(x => x.Id == editadoPessoa.Id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Telefone.Update(editadoPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Telefone.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse; ;
        }
        public async Task<ServiceResponse<List<Telefone>>> DeleteTelefone(int id)
        {
            ServiceResponse<List<Telefone>> serviceResponse = new ServiceResponse<List<Telefone>>();

            try
            {
                Telefone telefone = _context.Telefone.FirstOrDefault(x => x.Id == id);

                if (telefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Telefone.Remove(telefone);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Telefone.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;


        }
    }
}
