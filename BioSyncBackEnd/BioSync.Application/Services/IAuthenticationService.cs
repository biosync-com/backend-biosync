using System.Threading.Tasks;

namespace BioSync.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(string email, string senha);
    }
}
