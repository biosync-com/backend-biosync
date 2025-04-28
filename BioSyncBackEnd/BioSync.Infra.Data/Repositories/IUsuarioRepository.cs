using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioSync.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Endereco) 
                .Include(u => u.Agendamentos) 
                .ToListAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Endereco)
                .Include(u => u.Agendamentos) 
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .Include(u => u.Endereco) 
                .Include(u => u.Agendamentos)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
