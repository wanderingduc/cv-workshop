using backend.Data;
using backend.Data.Models;
using backend.Data.Requests;
using Microsoft.EntityFrameworkCore;

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
        return await context.Experiences.OrderBy(e => e.UserId).ToListAsync();
    }

    public async Task<Experience?> GetExperienceByIdAsync(Guid id)
    {
        // TODO: Oppgave 2 
        return await context.Experiences.FindAsync(id);
    }

    public async Task<IEnumerable<Experience>> GetExperiencesByTypeAsync(string type)
    {
        // TODO: Oppgave 3

        return await context.Experiences.Where(e => e.Type == type).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id) {
        return await context.Users.FindAsync(id);
    }


    // TODO: Oppgave 4 ny metode (husk å legge den til i interfacet)

    public async Task<IEnumerable<User>> GetUsersWithDesiredSkills(IEnumerable<string> desiredTechnologies)
    {
        return await context.Users.Where(u =>
        desiredTechnologies.Any(technology => u.Skills.Contains(technology)))
        .ToListAsync();
    }
    

    public async Task<IEnumerable<Experience>> GetExperiencesByUserIdAsync(Guid userid)
    {
        return await context.Experiences.Where(e => e.UserId == userid).ToListAsync();
    }

}
