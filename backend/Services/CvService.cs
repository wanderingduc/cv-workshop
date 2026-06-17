using backend.Data;
using backend.Data.Mappers;
using backend.Data.Models;

namespace backend.Services;

public class CvService(AppDbContext context) : ICvService
{
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await context.Users.OrderBy(u => u.Name).ToListAsync();
    }

    // TODO: Oppgave 1

    public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
    {
        // TODO: Oppgave 2
        return [];
    }

    public async Task<Experience?> GetExperienceByIdAsync(Guid id)
    {
        // TODO: Oppgave 2

        return null;
    }

    public async Task<IEnumerable<Experience>> GetExperiencesByTypeAsync(string type)
    {
        // TODO: Oppgave 3

        return [];
    }

    public async Task<User?> GetUserByIdAsync(Guid id) {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }
        return user;
    }


    // TODO: Oppgave 4 ny metode (husk å legge den til i interfacet)

}
