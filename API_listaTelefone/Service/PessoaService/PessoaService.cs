using API_listaTelefone.DataContext;
using API_listaTelefone.Models;
using Microsoft.EntityFrameworkCore;

namespace API_listaTelefone.Service.PessoaService
{
    public class PessoaService : IPessoaService
    {
        private readonly ApplicationDbContext _context;
        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Pessoa>>> CreatePessoa(Pessoa novaPessoa)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();
            try
            {
                if (novaPessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                
                
                _context.Add(novaPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;


        }

        public async Task<ServiceResponse<List<Pessoa>>> DeletePessoa(int id)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();

            try
            {
                Pessoa pessoa = _context.Pessoa.FirstOrDefault(x => x.Id == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Pessoa.Remove(pessoa);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Pessoa.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;


        }

        public async Task<ServiceResponse<List<Pessoa>>> GetPessoa()
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();
            try
            {

                serviceResponse.Dados = _context.Pessoa.ToList();

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


        public async Task<ServiceResponse<Pessoa>> GetPessoaById(int id)
        {
            ServiceResponse<Pessoa> serviceResponse = new ServiceResponse<Pessoa>();
            try
            {
                Pessoa pessoa = _context.Pessoa.FirstOrDefault(x => x.Id == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = pessoa;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;


        }

        public async Task<ServiceResponse<List<Pessoa>>> UpdatePessoa(Pessoa editadoPessoa)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();

            try
            {
                Pessoa pessoa = _context.Pessoa.AsNoTracking().FirstOrDefault(x => x.Id == editadoPessoa.Id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Pessoa.Update(editadoPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse; ;
        }

        
    }
}
