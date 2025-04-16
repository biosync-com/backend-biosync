using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.Repositories
{
    public class CategoriaMaterialRepository : ICategoriaMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaMaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaMaterial>> GetAllAsync()
        {
            return await _context.CategoriasMateriais.ToListAsync();
        }

        public async Task<CategoriaMaterial> GetById(int id)
        {
            return await _context.CategoriasMateriais.FindAsync(id);
        }

        public async Task<CategoriaMaterial> Create(CategoriaMaterial categoria)
        {
            _context.CategoriasMateriais.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<CategoriaMaterial> Update(CategoriaMaterial categoria)
        {
            _context.CategoriasMateriais.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<CategoriaMaterial> Delete(CategoriaMaterial categoria)
        {
            _context.CategoriasMateriais.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
