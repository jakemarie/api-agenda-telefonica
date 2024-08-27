using API_listaTelefone.DataContext;
using API_listaTelefone.Models;

namespace API_listaTelefone.Service.PessoaService
{
    public class PessoaService : IPessoaService
    {
        private readonly ApplicationDbContext _context;
        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetPessoa()
        {
           return _context.Pessoa.ToList();
        }
    }
}
