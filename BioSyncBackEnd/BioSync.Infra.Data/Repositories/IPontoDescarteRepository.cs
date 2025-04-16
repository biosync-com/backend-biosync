using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioSync.Infra.Data.Repositories
{
    public class PontoDescarteRepository : IPontoDescarteRepository
    {
        private readonly ApplicationDbContext _context;

        public PontoDescarteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontoDescarte>> GetAllAsync()
        {
            return await _context.PontosDescarte
                .Include(p => p.Endereco) 
                .Include(p => p.DiasFuncionamento) 
                .ToListAsync();
        }

        public async Task<PontoDescarte> GetById(int id)
        {
            return await _context.PontosDescarte
                .Include(p => p.Endereco)
                .Include(p => p.DiasFuncionamento) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PontoDescarte> Create(PontoDescarte pontoDescarte)
        {
            await _context.PontosDescarte.AddAsync(pontoDescarte);
            await _context.SaveChangesAsync();
            return pontoDescarte;
        }

        public async Task<PontoDescarte> Update(PontoDescarte pontoDescarte)
        {
            _context.PontosDescarte.Update(pontoDescarte);
            await _context.SaveChangesAsync();
            return pontoDescarte;
        }

        public async Task<PontoDescarte> Delete(PontoDescarte pontoDescarte)
        {
            _context.PontosDescarte.Remove(pontoDescarte);
            await _context.SaveChangesAsync();
            return pontoDescarte;
        }
    }
}
