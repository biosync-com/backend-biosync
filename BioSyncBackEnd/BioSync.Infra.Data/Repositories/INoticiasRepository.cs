using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.Repositories
{
    public class NoticiasRepository : INoticiasRepository
    {
        private readonly ApplicationDbContext _context;

        public NoticiasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Noticias>> GetAllAsync()
        {
            return await _context.Noticias.ToListAsync();
        }

        public async Task<Noticias> GetById(int id)
        {
            return await _context.Noticias
                                 .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Noticias> Create(Noticias noticias)
        {
            _context.Noticias.Add(noticias);
            await _context.SaveChangesAsync();
            return noticias;
        }

        public async Task<Noticias> Update(Noticias noticias)
        {
            _context.Noticias.Update(noticias);
            await _context.SaveChangesAsync();
            return noticias;
        }

        public async Task<Noticias> Delete(Noticias noticias)
        {
            var noticiasToDelete = await _context.Noticias.FindAsync(noticias.Id);
            if (noticiasToDelete == null)
            {
                return null;
            }

            _context.Noticias.Remove(noticiasToDelete);
            await _context.SaveChangesAsync();
            return noticiasToDelete;
        }
    }
}
