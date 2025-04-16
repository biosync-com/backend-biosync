using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            return await _context.Materiais
                                 .Include(m => m.CategoriaMaterial) 
                                 .ToListAsync();
        }

        public async Task<Material> GetById(int id)
        {
            return await _context.Materiais
                                 .Include(m => m.CategoriaMaterial) 
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Material> Create(Material material)
        {
            _context.Materiais.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        public async Task<Material> Update(Material material)
        {
            _context.Materiais.Update(material);
            await _context.SaveChangesAsync();
            return material;
        }

        
        public async Task<Material> Delete(Material material)
        {
            var materialToDelete = await _context.Materiais.FindAsync(material.Id);
            if (materialToDelete == null)
            {
                return null;
            }

            _context.Materiais.Remove(materialToDelete);
            await _context.SaveChangesAsync();
            return materialToDelete;
        }
    }
}
