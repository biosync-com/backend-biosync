using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.Repositories
{
    public class ConteudosRepository : IConteudosRepository
    {
        private readonly ApplicationDbContext _context;

        public ConteudosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Conteudos>> GetAllAsync()
        {
            return await _context.Conteudos.ToListAsync();
        }

        public async Task<Conteudos> GetById(int id)
        {
            return await _context.Conteudos.FindAsync(id);
        }

        public async Task<Conteudos> Create(Conteudos conteudo)
        {
            _context.Conteudos.Add(conteudo);
            await _context.SaveChangesAsync();
            return conteudo;
        }

        public async Task<Conteudos> Update(Conteudos conteudo)
        {
            _context.Conteudos.Update(conteudo);
            await _context.SaveChangesAsync();
            return conteudo;
        }

        public async Task<Conteudos> Delete(Conteudos conteudo)
        {
            _context.Conteudos.Remove(conteudo);
            await _context.SaveChangesAsync();
            return conteudo;
        }
    }
}
