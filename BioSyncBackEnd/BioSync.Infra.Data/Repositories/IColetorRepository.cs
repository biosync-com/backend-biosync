using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.Repositories
{
    public class ColetorRepository : IColetorRepository
    {
        private readonly ApplicationDbContext _context;

        public ColetorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Coletor> GetByEmailAsync(string email)
        {
            return await _context.Coletores.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<IEnumerable<Coletor>> GetAllAsync()
        {
            return await _context.Coletores.ToListAsync();
        }

        public async Task<Coletor> GetById(int id)
        {
            return await _context.Coletores.FindAsync(id);
        }

        public async Task<Coletor> Create(Coletor coletor)
        {
            _context.Coletores.Add(coletor);
            await _context.SaveChangesAsync();
            return coletor;
        }

        public async Task<Coletor> Update(Coletor coletor)
        {
            _context.Coletores.Update(coletor);
            await _context.SaveChangesAsync();
            return coletor;
        }

        public async Task<Coletor> Delete(Coletor coletor)
        {
            _context.Coletores.Remove(coletor);
            await _context.SaveChangesAsync();
            return coletor;
        }

        Task<Usuario> IColetorRepository.GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
